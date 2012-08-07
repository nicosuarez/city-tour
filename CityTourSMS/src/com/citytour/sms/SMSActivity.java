package com.citytour.sms;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

import com.citytour.sms.library.HTTPUtil;

public class SMSActivity extends Activity implements View.OnClickListener {
	private EditText urlTextField;
	private Button saveBtn;
	private CheckBox checkBox;
	public static final String PREFS_NAME = "CityTourPrefsFile";
	
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        urlTextField = (EditText) this.findViewById(R.id.editText1);
        
        saveBtn = (Button) this.findViewById(R.id.button1);
        saveBtn.setOnClickListener(this);
        
        checkBox = (CheckBox)this.findViewById(R.id.checkBox1);
        checkBox.setOnClickListener(this);
        
        SmsReceiver.smsActivity = this;
        
        // Restore preferences
        SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
        String url = settings.getString("WSURL", getString(R.string.WSURLDefault));
        urlTextField.setText(url, EditText.BufferType.EDITABLE);
        checkBox.setChecked(settings.getBoolean("respondSMS", true));
    }
    
    public void onClick(View v) {
    	SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
    	SharedPreferences.Editor editor = settings.edit();
    	
    	if (v == saveBtn) {
    		HTTPUtil.WSURL = urlTextField.getText().toString();
    		editor.putString("WSURL", urlTextField.getText().toString());
    		editor.commit();    		
    		Toast.makeText(this, getString(R.string.WSURLMessage), Toast.LENGTH_SHORT).show();
    	} else if(v == checkBox) {
    	      editor.putBoolean("respondSMS", checkBox.isChecked());
    	      editor.commit();
    	}
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
