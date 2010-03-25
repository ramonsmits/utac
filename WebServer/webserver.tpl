<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8">
<title>{$title}</title>
<style type="text/css">
body {
margin:auto; background: #ddd;
text-align: center;
font-family:Tahoma,Arial, Helvetica, sans-serif;
font-size:11px;
}
html {
margin:auto; background: #ddd;
text-align: center;
font-family:Tahoma,Arial, Helvetica, sans-serif;
font-size:11px;
}
#main {
margin:30 auto;
text-align: center;
background: #eee;
width:600px;
border: 1px solid #ccc;
}
#title {
font-size:28px;
font-style:italic;
font-weight:bold;
margin: 30px;
}
#temp {
width:200px;
font-size:24px;
font-weight:bold;
margin: 10px auto;
text-align: center;
border: 1px solid #ccc;
}
#timestamp {
font-size:10px;
text-align: right;
font-weight:normal;
margin-bottom: 5px;
}
</style>
</head>
<body>
<div id="main">
<div id="title">{$title}</div>
<div id="temp">
{$actualtemp}<br />
<div id="timestamp">
{$actualtimestamp}
</div>
</div>
{$refreshlink} - {$manualtempupdatelink}
<br /><br /><br />{$graph}<br /><br />
{$list}
<br /><br /></div><div id="powered"><a href="http://blog.n4rf.net/solutions/utac">powered by USB TEMPer Advanced Control</a></div></body>
</html>
