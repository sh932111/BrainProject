<?php
header("Access-Control-Allow-Origin: *");
header('Content-Type: text/html; charset=utf8');

include "../../database/DatabaseUtils.php";

$db_utils = new DatabaseUtils();

$root = $_GET["root"];

if ($root == "yoga") {
	$user_link = $db_utils -> initUserDatabase();
	if(!$db_utils -> deleteDatabase($user_link,DBName::getUserDB)) {
		echo mysql_error();
	}
	mysql_close ($user_link);
	$product_link = $db_utils -> initProductDatabase();
	if(!$db_utils -> deleteDatabase($product_link,DBName::getProductDB)) {
		echo mysql_error();
	}
	mysql_close ($product_link);
	$shared_link = $db_utils -> initSharedDatabase();
	if(!$db_utils -> deleteDatabase($shared_link,DBName::getSharedDB)) {
		echo mysql_error();
	}
	mysql_close ($shared_link);
	$sharing_link = $db_utils -> initSharingDatabase();
	if(!$db_utils -> deleteDatabase($sharing_link,DBName::getSharingDB)) {
		echo mysql_error();
	}
	mysql_close ($sharing_link);
}

?>