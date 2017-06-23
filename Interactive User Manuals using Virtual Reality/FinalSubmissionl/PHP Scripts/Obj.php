<?php

$conn = mysql_connect("localhost", "root", "");

if (!$conn) {
    echo "Unable to connect to DB: " . mysql_error();
    exit;
}
if (!mysql_select_db("objectcomponents")) {
    echo "Unable to select objectcomponents: " . mysql_error();
    exit;
}

	$Type=$_REQUEST["Type"];
	//$Password=$_REQUEST["Password"];
	
	if(!$Type)
	{
		echo"Empty";
		
	}
	else
	
	{
		
		$sql = "SELECT `Name` FROM `objtype` where `Type` = '" . $Type . "'";
		

		$result = mysql_query($sql);

		
		if(!$result === FALSE)
		{
	
			while($row = mysql_fetch_assoc($result)){
					$json[] = $row;
				}
	        	
				echo json_encode($json);
			
		}
		else
			echo mysql_error();
			
	}

	
?>