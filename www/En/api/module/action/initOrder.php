<?php
header("Access-Control-Allow-Origin: *");
header('Content-Type: text/html; charset=utf8');

//將時區設定為台灣
date_default_timezone_set('Asia/Taipei');

include "../../database/DatabaseUtils.php";

$db_utils  = new DatabaseUtils();
$user_link = $db_utils -> initUserDatabase();
if (mysql_select_db(DBName::getUserDB)) {
	$db_utils -> createOrderTable($user_link);
	$db_utils -> createOrderDetailTable($user_link);
}
mysql_close ($user_link);
?>