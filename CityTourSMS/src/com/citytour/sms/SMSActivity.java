package com.citytour.sms;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.citytour.sms.library.HTTPUtil;

public class SMSActivity extends Activity implements View.OnClickListener {
	private EditText urlTextField;
	private Button saveBtn;
	
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        urlTextField = (EditText) this.findViewById(R.id.editText1);
        saveBtn = (Button) this.findViewById(R.id.button1);
        saveBtn.setOnClickListener(this);
        SmsReceiver.smsActivity = this;
    }
    
    public void onClick(View v) {
    	HTTPUtil.WSURL = urlTextField.getText().toString();
    	 Toast.makeText(this, getString(R.string.WSURLMessage), Toast.LENGTH_SHORT).show(); 
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
