package com.citytour.sms;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;

public class SMSActivity extends Activity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        SmsReceiver.smsActivity = this;
    }
    
    public void sendMMS(String phoneNumber, String message, String filePath, String mimeType)
    {    	    	
    	Intent smsIntent = new Intent(Intent.ACTION_SEND);           	
    	smsIntent.putExtra("address", phoneNumber);
    	smsIntent.putExtra("sms_body", message);
    	smsIntent.setType(mimeType);
    	smsIntent.putExtra(Intent.EXTRA_STREAM, Uri.parse(filePath));    	    	
    	startActivity(smsIntent);    	
    }
}
