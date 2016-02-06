<?php
	$project = "/En";
	$AppPath = dirname(__FILE__) . $project;
	$sites_file = $AppPath . "/config/sites.json";
	$file_parse = file_get_contents($sites_file);
	$sitesJson = json_decode($file_parse, true);
	$index = "." . $project . "/body/pages" . $sitesJson["index"];
	echo '<script> window.location="' . $index . '"</script> ';
?>