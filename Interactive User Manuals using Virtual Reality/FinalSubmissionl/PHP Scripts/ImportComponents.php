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
/*

//For Server
	$servername="localhost";
	$usernameP="root";
	$passwordP="";
	$dbname="objectcomponents";
	
	
	$conn=new mysqli($servername,$usernameP,$passwordP,$dbname);
	if(!$conn)
	{
		die("Connection Failed....".mysqli_connect_error());
	}

	//$Email = isset($_GET["Email"]) ? $_GET["Email"] : null;
	//$Password = isset($_GET["Password"]) ? $_GET["Password"] : null;
	
	//$Email = 'g';
	//$Password = 12;
	/// objId,sourcePos,targetPos,targetRotation,sourceRotation, meshName
	
	*/
	$objId=$_REQUEST["objId"];
	//$Password=$_REQUEST["Password"];
	
	if(!$objId)
	{
		echo"Empty";
		
	}
	else
	{
		
		//$sql="SELECT * FROM `objcomponent` WHERE `objId` = '" . $objId . "'";
		//$result=mysqli_query($conn,$sql);
		
$sql = "SELECT * FROM `objcomponent` WHERE `objId` = '" . $objId . "'";

$result = mysql_query($sql);

		
		if(!$result === FALSE)
		{


	//$data= @mysql_fetch_array($result);
			//	if(strcmp($Password,$data["Password"]))
			//	{
			//		//echo "Success";
			//	}
			//	else
			//		echo "WrongPassword";
		
		

			while($row = mysql_fetch_assoc($result)){
					$json[] = $row;
				}
	        	
				echo json_encode($json);
			
		}
		else
			echo mysql_error();
			
	}
	
	//mysql_close();
	
?>