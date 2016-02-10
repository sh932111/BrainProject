<?php
header("Access-Control-Allow-Origin: *");
header('Content-Type: text/html; charset=utf8');
date_default_timezone_set('Asia/Taipei');
include "../../database/DatabaseUtils.php";
include "../../utils/TimeUtils.php";
include "../../utils/tokenUtils.php";
$data = $_POST["data"];
if(get_magic_quotes_gpc()){
	$data = stripslashes($_POST['data']);
}
else{
	$data = $_POST['data'];
}
$obj = json_decode($data,true);
$orderID 		= $obj["orderID"];
$db_utils 		= new DatabaseUtils();
$update_time 	= TimeUtils::getNowTime();
$start_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	$select_array = array(
		"orderID" => $orderID
		);
	$selectOrder = $db_utils -> selectTableAnd($user_link , TableName::getOrderTable,$select_array);
	$orderRecord = mysql_fetch_array($selectOrder);
	$wordNum = (int)$orderRecord['wordNum'];
	$selectDetail = $db_utils -> selectTableAnd($user_link , TableName::getOrderDetailTable,$select_array);
	if (!$selectDetail) {
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$code = 0;
	while ($record = mysql_fetch_array($selectDetail)) {
		$code ++;
	}
	if ($code != $wordNum ) {
		$db_utils -> responseError($start_time ,"單字尚未選滿！要選好選滿R！" , 209 , $user_link);
	}
	$obj["status"] = 2;
	if(!$db_utils -> updateData($user_link , TableName::getOrderTable , $obj , "orderID" , $orderID)){
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$res["message"]  = "更新資料成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>