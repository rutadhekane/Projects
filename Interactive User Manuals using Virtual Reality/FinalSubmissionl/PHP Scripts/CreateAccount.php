<?php
//For Server
	$servername="localhost";
	$usernameP="root";
	$passwordP="";
	$dbname="unitydb";
	
 try {
           $dbh = new PDO('mysql:host='. $servername .';dbname='. $dbname, $usernameP, $passwordP);
       } catch(PDOException $e) {
           echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
       }


	
	//mysql_connect($servername,$usernameP,$passwordP) or die("Can't Connect to DB");
	//mysql_select_db($dbname) or die("Can't Connect to DB");
	
	
	
		$conn=new mysqli($servername,$usernameP,$passwordP,$dbname);
	if(!$conn)
	{
		die("Connection Failed....".mysqli_connect_error());
	}
	
	
	
	
	$Email=$_REQUEST["Email"];
	$Password=$_REQUEST["Password"];
	
	if(!$Email || !$Password)
	{
		echo"Empty";
		
	}
	
	else
	{
		$sql="SELECT * FROM userlogin where Email='" . $Email . "'";
		
		$result=mysqli_query($conn,$sql);
		//$result=@mysql_query($sql) or die("Database error");
		
		//$Total=mysql_num_rows($result);
		if(mysqli_num_rows($result)==0)
		{
			$sth = $dbh->prepare("INSERT INTO `userlogin` (`Id`, `Email`, `Password`) VALUES (NULL, '".$Email."', '".$Password."')");
           try {
               $sth->execute($_GET);
			   
           } catch(Exception $e) {
               echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
           }
			echo"Success";
		}
		else
		{
			echo"AlreadyUsed";
		}
		
	}
	//mysql_close();
?>