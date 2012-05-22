package com.citytour.sms;

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
            	
            	String response = generateResponse(context, smsBody);
            	
                sendSMS(context, originalAddress, response);        
                
                showMessage(context, originalAddress, smsBody);
            }
        } 
	}
	
	public String generateResponse(Context context, String smsBody)
	{
		String[] tokens = smsBody.split(" ");
		String response = context.getString(R.string.InvalidBodySMS);;
		if (tokens[0].equals("Taxi") && tokens.length>2)
		{
			//TODO: Hacer llamado a web services para generar la reserva
			response = "Taxi reservado. Movil 1520 TaxiPremium";
		} else if (tokens[0].equals("Pago") && tokens.length == 4) {
			//TODO: Hacer llamado a web services para generar el pago			
			response = "Pago aceptado por $120,40. Nro 1234. Movil 1529";   
		} else if (tokens[0].equals("Audioguia") && tokens.length == 2) {
			//TODO: Hacer llamado a web services para obtener la url de la audioguia
			String audioId = tokens[1];
			response = "Reproducí tu audioguia en http://citytour.com/audioguia/" + audioId;
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
	
    //---display the new SMS message---    
    public void showMessage(Context context, String originalAddress, String smsBody)
    {
        String str = "SMS from " + originalAddress + " :" + smsBody;
        Toast.makeText(context, str, Toast.LENGTH_SHORT).show();    	
    }
}
