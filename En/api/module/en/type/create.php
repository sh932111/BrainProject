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
$list   	= $obj["list"]; /*Dictionary:enTypeName(string)*/
$db_utils 		= new DatabaseUtils();
$update_time 	= TimeUtils::getNowTime();
$start_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	for ($i=0; $i < count($list); $i++) { 
		$enTypeDiry = $list[$i];
		$enTypeDiry["enTypeID"] = TimeUtils::getId();
		$enTypeDiry["create_time"] = $update_time;
		$enTypeDiry["update_time"] = $update_time;
		$db_utils -> addENTypeTable($user_link,$enTypeDiry);
	}
	$res["message"] = "加入成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>