package com.citytour.sms;

import java.io.File;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Environment;
import android.telephony.SmsManager;
import android.telephony.SmsMessage;
import android.widget.Toast;
import com.citytour.sms.library.HTTPUtil;

public class SmsReceiver extends BroadcastReceiver
{
	public static SMSActivity smsActivity;
	
	@Override
	public void onReceive(Context context, Intent intent) {	
		
		if (!isServiceEnable(context))
			return;
		
        //---get the SMS message passed in---
        Bundle bundle = intent.getExtras();        
        SmsMessage[] msgs = null;
   
        if (bundle != null)
        {
            //---retrieve the SMS message received---
            Object[] pdus = (Object[]) bundle.get("pdus");
            msgs = new SmsMessage[pdus.length];           

            for (int i=0; i<msgs.length; i++){           			
                msgs[i] = SmsMessage.createFromPdu((byte[])pdus[i]);
            	String originalAddress = msgs[i].getOriginatingAddress();
            	String smsBody = msgs[i].getMessageBody().toString().toUpperCase();
            	
            	smsActivity.logSMS("[SMS de " + originalAddress + "] " + smsBody);
            	
				try {
	            	if ( isAudioguideRequest(context, smsBody) )
	            	{
	            		sendAudioguide(context, originalAddress, smsBody);
	            	} else {
	
						String response = generateResponse(context, smsBody);
	            		sendSMS(context, originalAddress, response);        		
	            	}
				} catch (Exception e) {
					smsActivity.logSMS("[Error de comunicacion]");
				}                
            }
        } 
	}
	
	public boolean isServiceEnable(Context context) {
        SharedPreferences settings = context.getSharedPreferences(SMSActivity.PREFS_NAME, 0);
        return settings.getBoolean("respondSMS", true);
		
	}
	
	public boolean isAudioguideRequest(Context context, String smsBody)
	{
		String[] tokens = smsBody.split(" ");
		if (tokens[0].equals(context.getString(R.string.SMSAudioguide)) || tokens[0].equals(context.getString(R.string.SMSAudioguide2)))
			return (tokens.length == 2); 
		return  false ;
	}
	
	public String generateResponse(Context context, String smsBody) throws Exception
	{	
		String[] tokens = smsBody.split(" ");
		String response = "";
		
		if (tokens.length>2 && tokens[0].equals(context.getString(R.string.SMSTaxi)))
		{
			String address = smsBody.substring(tokens[0].length() + 1);
			response = HTTPUtil.requestTaxi(address);
		} else if ((tokens.length == 4) && tokens[0].equals(context.getString(R.string.SMSPay))) {
			response = HTTPUtil.payTaxi(tokens[2], tokens[3]);			
		} else {
			response = context.getString(R.string.InvalidBodySMS);			
		}
			
		return response;
	}
	
    //---sends an SMS message to another device---
    public void sendSMS(Context context, String phoneNumber, String message)
    {        
        PendingIntent pi = PendingIntent.getBroadcast(context, 0, new Intent(context, context.getClass()), 0);                
        SmsManager sms = SmsManager.getDefault();
        sms.sendTextMessage(phoneNumber, null, message, pi, null);        
        smsActivity.logSMS("[Respuesta a " + phoneNumber + "] " + message);  
    }  
    
    public void sendAudioguide(Context context, String phoneNumber, String smsBody) throws Exception
    {
    	String[] tokens = smsBody.split(" ");
    	String message = HTTPUtil.audioguide(tokens[1]);
    	
    	String filePath = Environment.getExternalStorageDirectory().getPath() + "/"+ tokens[1] + ".mp3";
    	if (!this.fileExists(context, filePath))
    	{
    		sendSMS(context, phoneNumber, context.getString(R.string.SMSFailureAudioguide));
    	} else {
    	
    		sendSMS(context, phoneNumber, message);
    		smsActivity.logSMS("[Respuesta a " + phoneNumber + "] " + message);
    		smsActivity.sendMMS(phoneNumber, context.getString(R.string.SMSSuccessAudioguide), "file://" + filePath, "audio/*");
    	}
    }
	     
    public void showMessage(Context context, String message)
    {
        Toast.makeText(context, message, Toast.LENGTH_SHORT).show();    	
    }
    
    public boolean fileExists(Context context, String fileName)
    {
    	File file = new File(fileName);
    	return file.exists();    	
    }
    
}
