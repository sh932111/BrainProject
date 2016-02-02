<?php
include "../utils/TimeUtils.php" ;
class DatabaseUtils {

	public function initUserDatabase() {
		mysql_query("SET NAMES 'utf8'");
		mysql_query("SET CHARACTER_SET_CLIENT='utf8'");
		mysql_query("SET CHARACTER_SET_RESULTS='utf8'");
		$link = mysql_connect("localhost","root","sh3599033");
		return $link;	
	}
	
	public function response($start_time,$data,$link) {
		$over_time = TimeUtils::getNowTime();
		$data["error_code"]  = 0;
		$data["result"]  	 = true;
		$data["start_time"]  = $start_time;
		$data["over_time"]   = $over_time;
		$res["data"]		 = $data;
		echo json_encode($res);
		if ($link) {
			mysql_close($link);
		}
		exit();
	}

	public function responseError($start_time, $error_msg,$error_code,$link) {
		$over_time = TimeUtils::getNowTime();
		$data["message"] 	 = $error_msg;
		$data["error_code"]  = $error_code;
		$data["result"]  	 = false;
		$data["start_time"]  = $start_time;
		$data["over_time"]   = $over_time;
		$res["data"]		 = $data;
		echo json_encode($res);
		if ($link) {
			mysql_close($link);
		}
		exit();
	}

	public function createDatabase($link,$db_name) {
		$action = "CREATE DATABASE `$db_name`";
		return mysql_query($action, $link);
	}

	/*Delete*/
	public function deleteDatabase($link,$db_name) {
		$action = "DROP DATABASE `$db_name`";
		return mysql_query($action, $link);
	}
		//刪除table
	public function deleteTable($link,$table_name) {
		$action = "DROP TABLE IF EXISTS `$table_name`";
		return mysql_query($action, $link);
	}
		//指定刪除table的某比資料
	public function deleteTableData($link,$table_name,$key,$value) {
		$action = "DELETE FROM `$table_name` WHERE " . $key . " = '$value'";
		return mysql_query($action,$link);
	}

	public function deleteTableDataAnd($link,$table_name,$key,$value,$where_obj) {
		$sql = "DELETE FROM `$table_name` WHERE `" . $key . "` = '$value' ";
		foreach ($where_obj as $key => $value) {
			$item_value = $where_obj[$key];
			if (!empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}
		// return $sql;
		return mysql_query($sql,$link);
	}
	/*Delete*/

	/*Select*/

	public function selectTable($link,$table_name) {
		$action = sprintf("SELECT * FROM `$table_name`");
		return mysql_query($action, $link);
	}

	public function selectTableWithDate($link,$table_name,$obj,$reskey,$date1,$date2) {

		$sql = "SELECT * FROM `$table_name`";

		$check = true;
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if ($check && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . " WHERE `" . $key . "` = '" . $item_value . "' ";
				$check = false;
			}
			if (!$check && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}

		$sql = $sql . " AND `$reskey` BETWEEN '$date1' AND '$date2' ";
		$sql = $sql . " ORDER BY `" . $reskey . "` DESC";
		//return $sql;
		$action = sprintf($sql);
		return mysql_query($action, $link);
	}

	public function selectTableLike($link,$table_name,$value) {

		$sql = "SELECT * FROM `$table_name` WHERE class_name LIKE '%$value%'";

		$query = mysql_query($sql);

		return $query;
	}

	public function selectTableAnd($link,$table_name,$obj) {
		$sql = "SELECT * FROM `$table_name`";
		$check = true;
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if ($check && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . " WHERE `" . $key . "` = '" . $item_value . "' ";
				$check = false;
			}
			if (!$check && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}
		$action = sprintf($sql);
		return mysql_query($action, $link);
	}

	public function selectTableAndDESC($link,$table_name,$obj,$from_key) {
		$sql = "SELECT * FROM `$table_name`";
		$check = true;
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if ($check && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . " WHERE `" . $key . "` = '" . $item_value . "' ";
				$check = false;
			}
			if (!$check && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}
		$sql = $sql . " ORDER BY `" . $from_key . "` DESC";
		$action = sprintf($sql);
		return mysql_query($action, $link);
	}

	public function selectTableAndNotNull($link,$table_name,$obj) {
		$sql = "SELECT * FROM `$table_name`";
		$check = true;
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if ($check) {
				$sql = $sql . " WHERE `" . $key . "` = '" . $item_value . "' ";
				$check = false;
			}
			if (!$check) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}

		$action = sprintf($sql);
		return mysql_query($action, $link);
	}

	public function selectTableAndNotNullFromORDER($link,$table_name,$obj,$from_key) {
		$sql = "SELECT * FROM `$table_name`";
		$check = true;
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if ($check) {
				$sql = $sql . " WHERE `" . $key . "` = '" . $item_value . "' ";
				$check = false;
			}
			if (!$check) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}

		$sql = $sql . " ORDER BY `" . $from_key . "` ASC";

		$action = sprintf($sql);
		return mysql_query($action, $link);
	}

	public function selectTableDate($link,$table_name,$obj) {
		$sql = "SELECT * FROM `$table_name`";
		$check = 1;
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if ($check == 1 && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . " WHERE `" . $key . "` >= '" . $item_value . "' ";
				$check = 2;
			}
			if ($check == 2 && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` <= '$item_value' ";
				$check = 3;
			}
			if ($check == 3 && !empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` = '$item_value' ";
			}
		}
		$action = sprintf($sql);
		return mysql_query($action, $link);
	}
	public function userLogin($link,$table_name,$obj) {
		$user_name 	   = $obj["user_name"];
		$user_password = $obj["user_password"];
		$action = sprintf("SELECT * FROM `$table_name` WHERE 
			user_name = '$user_name' AND user_password = '$user_password'");
		return mysql_query($action, $link);
	}
	public function checkLogin($link,$table_name,$obj) {
		$user_name 	   = $obj["user_name"];
		if (array_key_exists("token",$obj)) {
			$token = $obj["token"];
			$action = sprintf("SELECT * FROM `$table_name` WHERE 
				user_name = '$user_name' AND token = '$token'");
			return mysql_query($action, $link);
		}
		else if (array_key_exists("phone_token",$obj)) {
			$phone_token = $obj["phone_token"];
			$action = sprintf("SELECT * FROM `$table_name` WHERE 
				user_name = '$user_name' AND phone_token = '$phone_token'");
			return mysql_query($action, $link);
		}
		else {
			return NULL;
		}
	}
	public function SelectListToParentId($link,$table_name,$parent_id) {
		$action = sprintf("SELECT * FROM `$table_name` WHERE parent_id = '$parent_id'");
		$obj 	= mysql_query($action, $link);
		if (mysql_num_rows($obj) > 0) {
			$list = array();
			while ($record   = mysql_fetch_array($obj)) {
				$class_id  = $record['class_id'];
				array_push($list, $class_id);
				$get_array   = $this -> SelectListToParentId($link,$table_name,$class_id);
				$array_count = count($get_array);
				for ($i = 0; $i < $array_count; $i ++) {
					array_push($list,$get_array[$i]);
				}
			}
			return $list;
		}
		else {
			return array();
		}
	}

	/*Select*/

	/*Update*/

	public function updateData($link,$table_name,$obj,$primary_key,$primary_value) {
		$sql    = "UPDATE `$table_name` SET ";
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			if (!empty($item_value) && strlen($item_value ) > 0) {
				$sql = $sql . "`" . $key . "` = '$item_value' ,";
			}
		}
		$sql = $sql . "`" . $primary_key . "` = '$primary_value' ";
		$sql = $sql . "WHERE `" . $primary_key . "` = '" . $primary_value . "';";
		$action = sprintf($sql);
		return mysql_query($action,$link);
	}
	public function clearData($link,$table_name,$obj,$primary_key,$primary_value) {
		$sql    = "UPDATE `$table_name` SET ";
		$index  = 0;
		$length = count($obj);
		foreach ($obj as $key => $value) {
			$item_value = $obj[$key];
			$sql = $sql . "`" . $key . "` = '$item_value' ";
			if ($index != $length - 1) {
				$sql = $sql . ",";
			}
			$index ++ ;
		}
		$sql = $sql . "WHERE `" . $primary_key . "` = '" . $primary_value . "';";
		$action = sprintf($sql);
		return mysql_query($action,$link);
	}
	public function updateDataAnd($link,$table_name,$obj,$primary_key,$primary_value,$where_obj) {
		$sql    = "UPDATE `$table_name` SET ";
		foreach ($obj as $key => $value) {
			$obj_item_value = $obj[$key];
			if (!empty($obj_item_value) && strlen($obj_item_value ) > 0) {
				$sql = $sql . "`" . $key . "` = '$obj_item_value' ,";
			}
		}
		$sql = $sql . "`" . $primary_key . "` = '$primary_value' ";
		$sql = $sql . "WHERE `" . $primary_key . "` = '" . $primary_value . "' ";
		foreach ($where_obj as $key => $value) {
			$where_item_value = $where_obj[$key];
			if (!empty($where_item_value) && strlen($where_item_value ) > 0) {
				$sql = $sql . "AND `" . $key . "` = '$where_item_value' ";
			}
		}
		// return $sql;
		$action = sprintf($sql);
		return mysql_query($action,$link);
	}

	/*Update*/

	/*Create*/

	public function createENTypeTable($link) {
		$table_name = TableName::getENTypeTable;
		$action = "CREATE TABLE `$table_name`(
			`enTypeID`   		VARCHAR(100)  	NOT NULL PRIMARY KEY ,
			`enTypeName`   		VARCHAR(100)  	NOT NULL ,
			`create_time` 		DATETIME 		NOT NULL ,
			`update_time` 		DATETIME 	 	NOT NULL );" ;
return mysql_query($action, $link);
}
public function createENWordTable($link) {
	$table_name = TableName::getENWordTable;
	$action = "CREATE TABLE `$table_name`(
		`enWordID`   		VARCHAR(100)  	NOT NULL PRIMARY KEY ,
		`enWord`   			VARCHAR(100)  	NOT NULL ,
		`enTypeID`   		VARCHAR(100)  	NOT NULL ,
		`create_time` 		DATETIME 		NOT NULL ,
		`update_time` 		DATETIME 	 	NOT NULL );" ;
return mysql_query($action, $link);
}
public function createWordDefinitionTable($link) {
	$table_name = TableName::getWordDefinitionTable;
	$action = "CREATE TABLE `$table_name`(
		`enDefinitionID`   	VARCHAR(100)  	NOT NULL PRIMARY KEY ,
		`enDefinition`   	VARCHAR(100)  	NOT NULL ,
		`enWordID`   		VARCHAR(100)  	NOT NULL ,
		`create_time` 		DATETIME 		NOT NULL ,
		`update_time` 		DATETIME 	 	NOT NULL );" ;
return mysql_query($action, $link);
}
public function createWordTranslateTable($link) {
	$table_name = TableName::getWordTranslateTable;
	$action = "CREATE TABLE `$table_name`(
		`enTranslateID`   	VARCHAR(100)  	NOT NULL PRIMARY KEY ,
		`enTranslate`   	VARCHAR(100)  	NOT NULL ,
		`enWordID`   		VARCHAR(100)  	NOT NULL ,
		`create_time` 		DATETIME 		NOT NULL ,
		`update_time` 		DATETIME 	 	NOT NULL );" ;
return mysql_query($action, $link);
}
public function createWordExampleTable($link) {
	$table_name = TableName::getWordExampleTable;
	$action = "CREATE TABLE `$table_name`(
		`enExampleID`   	VARCHAR(100)  	NOT NULL PRIMARY KEY ,
		`enExample`   		VARCHAR(10000)  	NOT NULL ,
		`zhExample`   		VARCHAR(10000)  	NOT NULL ,
		`enWordID`   		VARCHAR(100)  	NOT NULL ,
		`create_time` 		DATETIME 		NOT NULL ,
		`update_time` 		DATETIME 	 	NOT NULL );" ;
return mysql_query($action, $link);
}
/*Create*/

/*Insert*/
public function addENTypeTable($link,$obj) {
	$table_name = TableName::getENTypeTable;
	$action = sprintf("INSERT INTO `$table_name`(
		`enTypeID`,`enTypeName`,`create_time`,`update_time`)
	VALUES ('%s','%s','%s','%s')",
	$obj["enTypeID"],
	$obj["enTypeName"],
	$obj["create_time"],
	$obj["update_time"]);
	return mysql_query($action,$link);
}
public function addENWordTable($link,$obj) {
	$table_name = TableName::getENWordTable;
	$action = sprintf("INSERT INTO `$table_name`(
		`enWordID`,`enWord`,`enTypeID`,`create_time`,`update_time`)
	VALUES ('%s','%s','%s','%s','%s')",
	$obj["enWordID"],
	$obj["enWord"],
	$obj["enTypeID"],
	$obj["create_time"],
	$obj["update_time"]);
	return mysql_query($action,$link);
}
public function addWordDefinitionTable($link,$obj) {
	$table_name = TableName::getWordDefinitionTable;
	$action = sprintf("INSERT INTO `$table_name`(
		`enDefinitionID`,`enDefinition`,`enWordID`,`create_time`,`update_time`)
	VALUES ('%s','%s','%s','%s','%s')",
	$obj["enDefinitionID"],
	$obj["enDefinition"],
	$obj["enWordID"],
	$obj["create_time"],
	$obj["update_time"]);
	return mysql_query($action,$link);
}
public function addWordTranslateTable($link,$obj) {
	$table_name = TableName::getWordTranslateTable;
	$action = sprintf("INSERT INTO `$table_name`(
		`enTranslateID`,`enTranslate`,`enWordID`,`create_time`,`update_time`)
	VALUES ('%s','%s','%s','%s','%s')",
	$obj["enTranslateID"],
	$obj["enTranslate"],
	$obj["enWordID"],
	$obj["create_time"],
	$obj["update_time"]);
	return mysql_query($action,$link);
}
public function addWordExampleTable($link,$obj) {
	$table_name = TableName::getWordExampleTable;
	$action = sprintf("INSERT INTO `$table_name`(
		`enExampleID`,`enExample`,`zhExample`,`enWordID`,`create_time`,`update_time`)
	VALUES ('%s','%s','%s','%s','%s','%s')",
	$obj["enExampleID"],
	$obj["enExample"],
	$obj["zhExample"],
	$obj["enWordID"],
	$obj["create_time"],
	$obj["update_time"]);
	return mysql_query($action,$link);
}

/*Insert*/
}

class DBName {
	const getUserDB    = "userdb";
}

class TableName {
	const getENTypeTable    	  = "ENType_Table";
	const getENWordTable    	  = "ENWord_Table";
	const getWordDefinitionTable  = "WordDefinition_Table";
	const getWordTranslateTable   = "WordTranslate_Table";
	const getWordExampleTable     = "WordExample_Table";
}

?>