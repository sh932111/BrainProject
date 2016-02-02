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
$wordList   	= $obj["wordList"]; /*Dictionary:enTypeName(string)*/
$db_utils 		= new DatabaseUtils();
$update_time 	= TimeUtils::getNowTime();
$start_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	for ($i=0; $i < count($wordList); $i++) { 
		$enWordDiry = $wordList[$i];
		$enWordID = TimeUtils::getId(); 
		$enWordDiry["enWordID"] = $enWordID;
		$enWordDiry["create_time"] = $update_time;
		$enWordDiry["update_time"] = $update_time;
		$db_utils -> addENWordTable($user_link,$enWordDiry);
		$configList = $enWordDiry["configList"];
		for ($x=0; $x < count($configList); $x++) { 
			$configDiry = $configList[$x];
			$configDiry["enExampleID"] = TimeUtils::getId();
			$configDiry["enDefinitionID"] = TimeUtils::getId();
			$configDiry["enTranslateID"] = TimeUtils::getId();
			$configDiry["enWordID"] = $enWordID;
			$configDiry["create_time"] = $update_time;
			$configDiry["update_time"] = $update_time;
			$db_utils -> addWordDefinitionTable($user_link,$configDiry);
			$db_utils -> addWordTranslateTable($user_link,$configDiry);
			$db_utils -> addWordExampleTable($user_link,$configDiry);
		}
	}
	$res["message"] = "加入成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>