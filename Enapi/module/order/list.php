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
$status = $obj["status"];
$db_utils 		= new DatabaseUtils();
$update_time 	= TimeUtils::getNowTime();
$start_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	$select_array = array(
		"status" => $status
		);
	$selectOrder = $db_utils -> selectTableAnd($user_link , TableName::getOrderTable,$select_array);
	$list = array();
	while ($orderRecord = mysql_fetch_array($selectOrder)) {
		$res["orderID"] = $orderRecord['orderID'];
		$res["deviceAddress"] = $orderRecord['deviceAddress'];
		$res["userName"] = $orderRecord['userName'];
		$res["userYearOld"] = (int)$orderRecord['userYearOld'];
		$res["testTime"] = (int)$orderRecord['testTime'];
		$res["status"] = (int)$orderRecord['status'];
		$res["testResult"] = (int)$orderRecord['testResult'];
		$res["wordNum"] = (int)$orderRecord['wordNum'];
		$res["create_time"] = $orderRecord['create_time'];
		$res["update_time"] = $orderRecord['update_time'];
		array_push($list,$res);
	}
	$over["list"]	 = $list;
	$over["message"]  = "取得資料成功！";
	$db_utils -> response($start_time ,$over , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>