package com.citytour.sms.library;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import android.util.Log;

public class HTTPUtil {
	public static String WSURL;
	
	public static String connect(String url, List<NameValuePair> params)
	{
		String result = "";
		
	    HttpClient httpclient = new DefaultHttpClient();

	    // Prepare a request object
	    HttpPost httppost = new HttpPost(url);
	    
	    //Add parameters
	    try {
	    	if (params != null && params.size() > 0)
	    		httppost.setEntity(new UrlEncodedFormEntity(params));
		} catch (UnsupportedEncodingException e1) {
			e1.printStackTrace();
			return result;
		}
	    
	    // Execute the request
	    HttpResponse response;
	    try {
	        response = httpclient.execute(httppost);
	        // Examine the response status
	        Log.i("Response: ", response.getStatusLine().toString());

	        // Get hold of the response entity
	        HttpEntity entity = response.getEntity();
	        // If the response does not enclose an entity, there is no need
	        // to worry about connection release
	        if (entity != null) {

	            // A Simple JSON Response Read
	            InputStream instream = entity.getContent();
	            result = convertStreamToString(instream);
	            // now you have the string representation of the HTML request
	            instream.close();
	        }
            return result;
	    } catch (Exception e) {
            return result;
	    }
	}	
	
	
    private static String convertStreamToString(InputStream is) {
	    /*
	     * To convert the InputStream to String we use the BufferedReader.readLine()
	     * method. We iterate until the BufferedReader return null which means
	     * there's no more data to read. Each line will appended to a StringBuilder
	     * and returned as String.
	     */
	    BufferedReader reader = new BufferedReader(new InputStreamReader(is));
	    StringBuilder sb = new StringBuilder();
	
	    String line = null;
	    try {
	        while ((line = reader.readLine()) != null) {
	            sb.append(line + "\n");
	        }
	    } catch (IOException e) {
	        e.printStackTrace();
	    } finally {
	        try {
	            is.close();
	        } catch (IOException e) {
	            e.printStackTrace();
	        }
	    }
	    return sb.toString();
	}
    
    public static String requestTaxi(String address) throws JSONException {
    	List<NameValuePair> params = new ArrayList<NameValuePair>(1);
    	params.add(new BasicNameValuePair("address", address));
    	String rawJson = HTTPUtil.connect(WSURL + "/api/reservations/taxi", params);    	
		JSONObject json = new JSONObject(rawJson);
		return json.getString("sms"); 
    }
    
    public static String payTaxi(String patent, String amount) throws JSONException {
    	List<NameValuePair> params = new ArrayList<NameValuePair>(2);
    	params.add(new BasicNameValuePair("patent", patent));
    	params.add(new BasicNameValuePair("amount", amount));    	
    	String rawJson = HTTPUtil.connect(WSURL + "/api/reservations/pagotaxi", params);
		JSONObject json = new JSONObject(rawJson);
		return json.getString("sms"); 
    }    
    
    public static String audioguide(String code) throws JSONException {
    	List<NameValuePair> params = new ArrayList<NameValuePair>(1);
    	params.add(new BasicNameValuePair("code", code));
    	String rawJson = HTTPUtil.connect(WSURL + "/api/audioguia", params);
		JSONObject json = new JSONObject(rawJson);
		return json.getString("sms"); 
    }   
}
