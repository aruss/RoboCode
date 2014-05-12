## aruss.RoboCode

About RoboCode: [http://robocode.sourceforge.net/](http://robocode.sourceforge.net/)


###Debug robots in VS (start a battle with F5)
[http://robowiki.net/wiki/Robocode/.NET/Debug_a_.NET_robot_in_Visual_Studio](http://robowiki.net/wiki/Robocode/.NET/Debug_a_.NET_robot_in_Visual_Studio)

#####Post-build event command line
`copy "$(ProjectDir)\test.battle" "C:\robocode\battles\test.battle" /Y`

#####Start external program 
`C:\Program Files (x86)\Java\jre7\bin\java.exe`

#####Command line arguments
`-Ddebug=true -Xmx1024M -Dsun.io.useCanonCaches=false -cp libs/robocode.jar;libs/jni4net.j-0.8.6.0.jar robocode.Robocode -battle battles\test.battle`

#####Working directory
`C:\robocode\`



