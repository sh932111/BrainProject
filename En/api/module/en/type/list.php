<?php
header("Access-Control-Allow-Origin: *");
header('Content-Type: text/html; charset=utf8');
date_default_timezone_set('Asia/Taipei');
include "../../../database/DatabaseUtils.php";
include "../../../utils/TimeUtils.php";
include "../../../utils/tokenUtils.php";
$data = $_POST["data"];
if(get_magic_quotes_gpc()){
	$data = stripslashes($_POST['data']);
}
else{
	$data = $_POST['data'];
}
$obj = json_decode($data,true);
$db_utils 		= new DatabaseUtils();
$start_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	$select_array = array();
	$select_obj = $db_utils -> selectTableAnd($user_link , TableName::getENTypeTable,$select_array);
	if (!$select_obj) {
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$list = array();
	while ($record = mysql_fetch_array($select_obj)) {
		$get["enTypeID"]     = $record['enTypeID'];
		$get["enTypeName"]   = $record['enTypeName'];
		$get["create_time"]  = $record['create_time'];
		$get["update_time"]  = $record['update_time'];
		array_push($list,$get);
	}
	$res["list"]	 = $list;
	$res["message"]  = "取得資料成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>