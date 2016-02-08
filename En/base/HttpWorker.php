<?php
class HttpWorker {
	private $postURL = null;
	function __construct($url) {
		$this->postURL = $url;
	}
	public function post($post) {
		$ch = curl_init();
		curl_setopt($ch, CURLOPT_URL, $this->postURL);
		curl_setopt($ch, CURLOPT_POST, true);
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($post)); 
		$result = curl_exec($ch); 
		curl_close($ch);
		return $result;
	}
}
?>