<?php

//For Server
	$servername="localhost";
	$usernameP="root";
	$passwordP="";
	$dbname="unitydb";
	
	//mysql_connect($servername,$usernameP,$passwordP) or die("Can't Connect to DB");
	//mysql_select_db($dbname) or die("Can't Connect to DB");
	
	$conn=new mysqli($servername,$usernameP,$passwordP,$dbname);
	if(!$conn)
	{
		die("Connection Failed....".mysqli_connect_error());
	}

	//$Email = isset($_GET["Email"]) ? $_GET["Email"] : null;
	//$Password = isset($_GET["Password"]) ? $_GET["Password"] : null;
	
	//$Email = 'g';
	//$Password = 12;
	
	
	$Email=$_REQUEST["Email"];
	$Password=$_REQUEST["Password"];
	
	if(!$Email || !$Password)
	{
		echo"Empty";
		
	}
	else
	{
		//$SQL="SELECT * FROM 'userlogin' where Email='" . $Email . "'";
		$sql="SELECT * FROM `userlogin` where Email='" . $Email . "'";
		$result=mysqli_query($conn,$sql);
		//$result_id=@mysql_query($SQL) or die("Database error");
		//$total=mysql_num_rows(result_id);
		
		if(mysqli_num_rows($result)>0)
		{
			$data= @mysql_fetch_array($result);
			if(strcmp($Password,$data["Password"]))
			{
				echo "Success";
			}
			else
				echo "WrongPassword";
		}
		else
			echo"EmailDoesNotExist";
		
	}
	
	//mysql_close();
	
?>