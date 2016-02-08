<?php
class GCMUtils {
	public function doSendGCM($registatoin_ids,$title,$message) {
	$sendMsg = array(
		"title" 	=> $title,
		"message" 	=> $message
		);
	$url = 'https://android.googleapis.com/gcm/send';
	$apiKey = 'AIzaSyAfPM-bRpj1CBYJaQ1sM2O6O-Wj9_3_DBU';
	define('GOOGLE_API_KEY', $apiKey);
	$fields = array(
		'registration_ids' => $registatoin_ids,
		'data' => $sendMsg
	);
	$headers = array(
		'Content-Type: application/json',
		'Authorization: key='.GOOGLE_API_KEY
	);
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	curl_setopt($ch, CURLOPT_POST, true);
	curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
	curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($fields));
	$result = curl_exec($ch);
	if ($result === FALSE) {
		die('Curl failed: ' . curl_error($ch));
	}
	curl_close($ch);
}
}

?>