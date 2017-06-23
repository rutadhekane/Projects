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

	
	$Type =$_REQUEST["Type"];
	
	if($Type == -1)
	{
		
		$sql = "SELECT * FROM `objtype`";
		

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
else
	{
		
		$sql = "SELECT * FROM `objtype` WHERE `Type` = '" . $Type . "'";
		

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