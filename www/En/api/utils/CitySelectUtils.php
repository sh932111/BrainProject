<?php
class CitySelectUtils {
	private $city_db_conn;
	function __construct($path) {
		try {
			$this->city_db_conn = new PDO($path);
		}
		catch(PDOException $e) {
			$data["message"] 	 = $e;
			$data["error_code"]  = 0;
			$data["result"]  	 = false;
			$res["data"]		 = $data;
			echo json_encode($res);
			exit();
		}
	}
	function __destruct() {
		try {
            $this->city_db_conn = null; //Closes connection
        } catch (PDOException $e) {
        	$data["message"] 	 = $e;
        	$data["error_code"]  = 0;
        	$data["result"]  	 = false;
        	$res["data"]		 = $data;
        	echo json_encode($res);
        	exit();
        }
    }
    public function selectPositionName($key) {
		$db_action = $this->city_db_conn;
		$str2 = "SELECT * FROM position WHERE position_id = '$key'";
		$sth2 = $db_action->prepare($str2);
		$sth2->execute();
		$row1 = $sth2->fetchAll();
		if (count($row1) > 0) {
			return $row1[0]['position'];
		}
		else {
			return "";
		}
    }
    public function selectPosition($key) {
    	$db_action = $this->city_db_conn;
    	if (!empty($key)) {
    		$sth1 = $db_action->prepare("SELECT * FROM position WHERE position_id = '$key'");
	    	$sth1->execute();
	    	$row1 = $sth1->fetchAll();
	    	return $row1;
    	}
    	else {
    		$sth1 = $db_action->prepare("SELECT * FROM position");
	    	$sth1->execute();
	    	$row1 = $sth1->fetchAll();
	    	return $row1;
    	}
    }
    public function selectCityName($key) {
		$db_action = $this->city_db_conn;
		$str2 = "SELECT * FROM city WHERE city_id = '$key'";
		$sth2 = $db_action->prepare($str2);
		$sth2->execute();
		$row1 = $sth2->fetchAll();
		if (count($row1) > 0) {
			return $row1[0]['territory_name'];
		}
		else {
			return "";
		}
    }
    public function selectCity($key) {
		$db_action = $this->city_db_conn;
		if (!empty($key)) {
			$str2 = "SELECT * FROM city WHERE position_id = '$key'";
			$sth2 = $db_action->prepare($str2);
			$sth2->execute();
			$row1 = $sth2->fetchAll();
	    	return $row1;
		}
		else {
			$str2 = "SELECT * FROM city";
			$sth2 = $db_action->prepare($str2);
			$sth2->execute();
			$row1 = $sth2->fetchAll();
	    	return $row1;
		}
    }
    public function selectAreaName($key) {
		$db_action = $this->city_db_conn;
		$str2 = "SELECT * FROM area WHERE district_id = '$key'";
		$sth2 = $db_action->prepare($str2);
		$sth2->execute();
		$row1 = $sth2->fetchAll();
		if (count($row1) > 0) {
			return $row1[0]['district_name'];
		}
		else {
			return "";
		}
    }
    public function selectArea($key) {
    	$db_action = $this->city_db_conn;
    	if (!empty($key)) {
    		$str2 = "SELECT * FROM area WHERE territory_name = '$key'";
    		$sth2 = $db_action->prepare($str2);
			$sth2->execute();
			$row1 = $sth2->fetchAll();
	    	return $row1;
    	}
    	else {
    		$str3 = "SELECT * FROM area";
    		$sth2 = $db_action->prepare($str3);
			$sth2->execute();
			$row1 = $sth2->fetchAll();
	    	return $row1;
    	}
    }
}
?>