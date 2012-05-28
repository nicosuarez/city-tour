package com.citytour.sms;

import java.io.File;

import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.telephony.SmsMessage;
import android.widget.Toast;

public class SmsReceiver extends BroadcastReceiver
{
	public static SMSActivity smsActivity;
	
	@Override
	public void onReceive(Context context, Intent intent) {
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
            	String smsBody = msgs[i].getMessageBody().toString();             			
            	
            	if ( isAudioguideRequest(context, smsBody) )
            	{
            		sendAudioguide(context, originalAddress, smsBody);
            	} else {
                	String response = generateResponse(context, smsBody);
            		sendSMS(context, originalAddress, response);
            	}
                
                showMessage(context, originalAddress, smsBody);
            }
        } 
	}
	
	public boolean isAudioguideRequest(Context context, String smsBody)
	{
		String[] tokens = smsBody.split(" ");
		return tokens[0].equals(context.getString(R.string.SMSAudioguide)) && tokens.length == 2;
	}
	
	public String generateResponse(Context context, String smsBody)
	{
		String[] tokens = smsBody.split(" ");
		String response = context.getString(R.string.InvalidBodySMS);
		if (tokens[0].equals(context.getString(R.string.SMSTaxi)) && tokens.length>2)
		{
			//TODO: Hacer llamado a web services para generar la reserva
			response = "Taxi reservado. Movil 1520 TaxiPremium";
		} else if (tokens[0].equals(context.getString(R.string.SMSPay)) && tokens.length == 4) {
			//TODO: Hacer llamado a web services para generar el pago			
			response = "Pago aceptado por $120,40. Nro 1234. Movil 1529";   
		}
			
		return response;
	}
	
    //---sends an SMS message to another device---
    public void sendSMS(Context context, String phoneNumber, String message)
    {        
        PendingIntent pi = PendingIntent.getBroadcast(context, 0, new Intent(context, context.getClass()), 0);                
        SmsManager sms = SmsManager.getDefault();
        sms.sendTextMessage(phoneNumber, null, message, pi, null);        
    }  
    
    public void sendAudioguide(Context context, String phoneNumber, String smsBody)
    {
    	String[] tokens = smsBody.split(" ");
    	String filePath = "/sdcard/" + tokens[1] + ".3gp";
    	if (!this.fileExists(context, filePath))
    	{
    		sendSMS(context, phoneNumber, context.getString(R.string.SMSFailureAudioguide));
    		return;
    	}

    	String message = context.getString(R.string.SMSSuccessAudioguide);
    	smsActivity.sendMMS(phoneNumber, message, "file://" + filePath, "video/3gp");
    	    	
    }
	  
    //---display the new SMS message---    
    public void showMessage(Context context, String originalAddress, String smsBody)
    {
        String str = "SMS from " + originalAddress + " :" + smsBody;
        Toast.makeText(context, str, Toast.LENGTH_SHORT).show();    	
    }
    
    public boolean fileExists(Context context, String fileName)
    {
    	File file = new File(fileName);
    	return file.exists();    	
    }
}
