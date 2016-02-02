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
$enWordID = $obj["enWordID"];
$db_utils 		= new DatabaseUtils();
$start_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	$select_enWord = array(
		"enWordID"  => $enWordID
		);
	$select_obj = $db_utils -> selectTableAnd($user_link , TableName::getENWordTable,$select_enWord);
	if (!$select_obj) {
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	$record = mysql_fetch_array($select_obj);
	$get["enWord"]       = $record['enWord'];
	$get["enWordID"]     = $record['enWordID'];
	$get["enTypeID"]     = $record['enTypeID'];
	$get["create_time"]  = $record['create_time'];
	$get["update_time"]  = $record['update_time'];
	$definitionList = array();
	$translateList = array();
	$exampleList = array();
	$definitionDiry = $db_utils -> selectTableAnd($user_link , TableName::getWordDefinitionTable,$select_enWord);
	while ($definitionRecord = mysql_fetch_array($definitionDiry)) {
		$getDefinition["enDefinitionID"] = $definitionRecord['enDefinitionID'];
		$getDefinition["enDefinition"] = $definitionRecord['enDefinition'];
		$getDefinition["enWordID"] = $definitionRecord['enWordID'];
		$getDefinition["create_time"] = $definitionRecord['create_time'];
		$getDefinition["update_time"] = $definitionRecord['update_time'];
		array_push($definitionList,$getDefinition);
	}
	$translateDiry = $db_utils -> selectTableAnd($user_link , TableName::getWordTranslateTable,$select_enWord);
	while ($translateRecord = mysql_fetch_array($translateDiry)) {
		$getTranslate["enTranslateID"] = $translateRecord['enTranslateID'];
		$getTranslate["enTranslate"] = $translateRecord['enTranslate'];
		$getTranslate["enWordID"] = $translateRecord['enWordID'];
		$getTranslate["create_time"] = $translateRecord['create_time'];
		$getTranslate["update_time"] = $translateRecord['update_time'];
		array_push($translateList,$getTranslate);
	}
	$exampleDiry = $db_utils -> selectTableAnd($user_link , TableName::getWordExampleTable,$select_enWord);
	while ($exampleRecord = mysql_fetch_array($exampleDiry)) {
		$getExample["enExampleID"] = $exampleRecord['enExampleID'];
		$getExample["enExample"] = $exampleRecord['enExample'];
		$getExample["zhExample"] 	= $exampleRecord['zhExample'];
		$getExample["enWordID"] 	= $exampleRecord['enWordID'];
		$getExample["create_time"] = $exampleRecord['create_time'];
		$getExample["update_time"] = $exampleRecord['update_time'];
		array_push($exampleList,$getExample);
	}
	$get["definitionList"] = $definitionList;
	$get["translateList"]  = $translateList;
	$get["exampleList"]  = $exampleList;
	$res["value"] 	 = $get;
	$res["message"]  = "取得資料成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>