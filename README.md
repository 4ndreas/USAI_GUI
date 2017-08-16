# USAI_GUI
GUI for my "Universal Sensor Actor Interface" (USAI) library for Arduino

The library uses a simple ASCII-protocoll to transfer data.
| Name | : | Value |\r\n|

The data of the example recived by the serial port looks like:
```
potiValue:0<\r><\n>
TXValue:296<\r><\n>
linCounter:122<\r><\n>
sinCounter:0.135105<\r><\n>
Red:219<\r><\n>
Greed:49<\r><\n>
Blue:49<\r><\n>
```

The GUI can display different controls depended on the variables set in the Arduino
Actor
- Boolean to button
- int and float to knob dails
- int32_t to RGB color selector

Sensors
- int, float to value

![lidarsee](images/USAI_GUI_controls.jpg)

To display time depended values graphs can be selected in the config tab

![lidarsee](images/USAI_GUI_graph.jpg)
![lidarsee](images/USAI_GUI_Config.jpg)

Currently Serial and UDP connections are supported
- Serial select the Port and baudrate
- UDP select IP and Port
![lidarsee](images/USAI_GUI_Connect.jpg)

# To do
- add crc for serial connection
- binarry protocoll
- TCP/IP
- save graphs and values
- Improve MIDI interface
- ... many more ideas 

