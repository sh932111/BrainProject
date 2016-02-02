<?php

class tokenUtils {

	public static function getToken() {
		$token  = md5(((float) date ( "YmdHis" ) + rand(100,999)).rand(1000,9999));
		return $token;
	}

	public static function setToken($obj,$device,$new_token) {
		$str = "";
		if (strlen($new_token) > 0) {
			$str = base64_encode($new_token);
		}
		switch ($device) {
			case 1:
			$obj["token"] = $str;
			break;
			case 2:
			$obj["phone_token"] = $str;
			break;
		}
		return $obj;
	}
}

?>