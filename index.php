<?php
$mailto=$_POST['mail_to'];
$mailSub=$_POST['mail_sub'];
$mailmsg=$_POST['mail_msg'];
require 'PHPMailer-master/PHPMailerAutoload.php'
$mail=new PHPMailer();
$mail ->IsSmtp():
$mail->SMTPAuth=true;
$mail->SMTPSecure='ssl';
$mail->Host="smtp.gmail.com";
$mail->Port=465;
$mail->IsHTML(true);
$mail->Username="mahammad.yagubli@gmail.com";
$mail->Password="password";
$mail->SetFrom("mahammad.yagubli@gmail.com");
$mail->Subject=$mailSub;
$mail->Body=$mailmsg;
$mail->AddAddress($mailto);
if(!$mail->Send()){
	
	echo "Mail Not Sent";
	
}
else {
	
	echo "Mail is Sent";
	
	
}
?>




 