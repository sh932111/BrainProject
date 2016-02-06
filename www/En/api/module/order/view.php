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
	$res = array();
	$select_array = array(
		"orderID" => $orderID
		);
	$selectOrder = $db_utils -> selectTableAnd($user_link , TableName::getOrderTable,$select_array);
	$orderRecord = mysql_fetch_array($selectOrder);
	$res["orderID"] = $orderRecord['orderID'];
	$res["userName"] = $orderRecord['userName'];
	$res["userYearOld"] = (int)$orderRecord['userYearOld'];
	$res["testTime"] = (int)$orderRecord['testTime'];
	$res["status"] = (int)$orderRecord['status'];
	$res["testResult"] = (int)$orderRecord['testResult'];
	$res["wordNum"] = (int)$orderRecord['wordNum'];
	$res["create_time"] = $orderRecord['create_time'];
	$res["update_time"] = $orderRecord['update_time'];
	$selectDetail = $db_utils -> selectTableAnd($user_link , TableName::getOrderDetailTable,$select_array);
	if (!$selectDetail) {
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$list = array();
	while ($record = mysql_fetch_array($selectDetail)) {
		$get["detailID"] 	= $record['detailID'];
		$get["orderID"] 	= $record['orderID'];
		$get["enWordID"] 	= $record['enWordID'];
		$get["test"] 		= $record['test'];
		$get["testResult"] 	= $record['testResult'];
		$get["create_time"] = $record['create_time'];
		$get["update_time"] = $record['update_time'];
		array_push($list,$get);
	}
	$over["value"] 	 = $res;
	$over["list"]	 = $list;
	$over["message"]  = "取得資料成功！";
	$db_utils -> response($start_time ,$over , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>