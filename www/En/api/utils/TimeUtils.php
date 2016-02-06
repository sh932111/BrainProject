<?php
class TimeUtils {
	//獲取現在時間
	public static function getNowTime() {
		return date ("Y/m/d H:i:s");
	}
	//id
	public static function getId() {
		return date("YmdHis").rand(1000,9999);
	}
}
?>