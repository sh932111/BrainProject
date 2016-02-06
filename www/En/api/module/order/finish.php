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
	$status = (int)$orderRecord['status'];
	if ($status == 3) {
		$db_utils -> responseError($start_time ,"已經結算過了！" , 163 , $user_link);
	}
	$wordNum = (int)$orderRecord['wordNum'];
	$score = 100 / $wordNum;
	$selectDetail = $db_utils -> selectTableAnd($user_link , TableName::getOrderDetailTable,$select_array);
	if (!$selectDetail) {
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$list = array();
	$userScore = 100;
	while ($detailRecord = mysql_fetch_array($selectDetail)) {
		$enWordID 	= $detailRecord['enWordID'];
		$test 		= $detailRecord['test'];
		$detailID 	= $detailRecord['detailID'];
		$select_enWord = array(
			"enWordID"  => $enWordID
			);
		$enWordObj = $db_utils -> selectTableAnd($user_link , TableName::getENWordTable,$select_enWord);
		if (!$enWordObj) {
			$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
		}
		$wordRecord = mysql_fetch_array($enWordObj);
		$enWord 	= $wordRecord['enWord'];
		if ($enWord == $test) {
			$updateDetailObj = array();
			$updateDetailObj["testResult"] = 1;
			if(!$db_utils -> updateData($user_link , TableName::getOrderDetailTable , $updateDetailObj , "detailID" , $detailID)){
				$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
			}
		}
		else {
			$userScore = $userScore - $score;
		}
	}
	$resultOrder["status"] = 3;
	$resultOrder["testResult"] = $userScore;
	if(!$db_utils -> updateData($user_link , TableName::getOrderTable , $resultOrder , "orderID" , $orderID)){
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$res["message"]  = "更新資料成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>