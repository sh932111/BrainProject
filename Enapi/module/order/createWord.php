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
	$selectDetail = $db_utils -> selectTableAnd($user_link , TableName::getOrderDetailTable,$select_array);
	if (!$selectDetail) {
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$detailNum = 0;
	while ($record = mysql_fetch_array($selectDetail)) {
		$detailNum ++;
	}
	if ($detailNum > 0) {
		$selectRoot = $db_utils -> selectTableAnd($user_link , TableName::getOrderTable,$select_array);
		if (!$selectRoot) {
			$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
		}
		$rootfetch = mysql_fetch_array($selectRoot);
		$wordNum = (int)$rootfetch["wordNum"];
		if ($detailNum >= $wordNum) {
			$db_utils -> responseError($start_time ,"無法加入，單字已經達上限！" , 300 , $user_link);
		}
		else {
			$detailID = TimeUtils::getId();
			$obj["detailID"] = $detailID;
			$obj["create_time"] = $update_time;
			$obj["update_time"] = $update_time;
			$db_utils -> addOrderDetailTable($user_link,$obj , "" , 2);
			$res["message"] = "加入成功！";
			$db_utils -> response($start_time ,$res , $user_link);
		}
	}
	else {
		$detailID = TimeUtils::getId();
		$obj["detailID"] = $detailID;
		$obj["create_time"] = $update_time;
		$obj["update_time"] = $update_time;
		$db_utils -> addOrderDetailTable($user_link,$obj , "" , 2);
		$res["message"] = "加入成功！";
		$db_utils -> response($start_time ,$res , $user_link);
	}
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>