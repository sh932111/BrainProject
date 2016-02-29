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
$enWord 		= $obj["enWord"];
$enWordID 		= $obj["enWordID"];
$definitionList = $obj["definitionList"];
$exampleList 	= $obj["exampleList"];
$translateList 	= $obj["translateList"];
$db_utils 		= new DatabaseUtils();
$start_time 	= TimeUtils::getNowTime();
$update_time 	= TimeUtils::getNowTime();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	$enWordObj = array(
		"enWord"  	=> $enWord
		);
	if(!$db_utils -> updateData($user_link , TableName::getENWordTable , $enWordObj , "enWordID" , $enWordID)){
		$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
	}
	for ($i=0; $i < count($definitionList); $i++) { 
		$definitionItem = $definitionList[$i];
		$enDefinition 	= $definitionItem["enDefinition"];
		$enDefinitionID = $definitionItem["enDefinitionID"];
		$enDefObj = array(
			"enDefinition"  	=> $enDefinition
		);
		if(!$db_utils -> updateData($user_link , TableName::getWordDefinitionTable , $enDefObj , "enDefinitionID" , $enDefinitionID)){
			$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
		}
		$exampleItem 	= $exampleList[$i];
		$zhExample 		= $exampleItem["zhExample"];
		$enExample 		= $exampleItem["enExample"];
		$enExampleID 	= $exampleItem["enExampleID"];
		$enExaObj = array(
			"enExample"  	=> $enExample,
			"zhExample"  	=> $zhExample
		);
		if(!$db_utils -> updateData($user_link , TableName::getWordExampleTable , $enExaObj , "enExampleID" , $enExampleID)){
			$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
		}
		$translateItem 	= $translateList[$i];
		$enTranslate 	= $translateItem["enTranslate"];
		$enTranslateID 	= $translateItem["enTranslateID"];
		$enTraObj = array(
			"enTranslate"  	=> $enTranslate
		);
		if(!$db_utils -> updateData($user_link , TableName::getWordTranslateTable , $enTraObj , "enTranslateID" , $enTranslateID)){
			$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
		}
	}
	$res["message"]  = "更新資料成功！";
	$db_utils -> response($start_time ,$res , $user_link);
}
else {
	$db_utils -> responseError($start_time ,mysql_error() , mysql_errno() , $user_link);
}
?>