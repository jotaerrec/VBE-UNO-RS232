#include <SoftwareSerial.h>

int led1 = 8;
SoftwareSerial rs232Serial(2, 3); // RX, TX Converter RS232 to TTL

void setup() {
  rs232Serial.begin(9600);
  Serial.begin(9600); // For debug
  pinMode(led1, OUTPUT);

}

void loop() {
  if (rs232Serial.available()) {
    String data = rs232Serial.readStringUntil('\n');    
    Serial.print(data); // DEBUG
    
    if (data.indexOf("led1") != -1 ) {
      int ind = data.indexOf(':');
      int dataLength = data.length();
      String rta = data.substring(ind + 1, dataLength);
      if (rta == "HIGH")
        digitalWrite(led1, HIGH);
      else
        digitalWrite(led1, LOW);
    }
    if (led1 != -1) {
      rs232Serial.print("Led 1 = ");
      rs232Serial.println(digitalRead(led1));
    }
  }

}
