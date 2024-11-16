// Below is an example of a simple robot program using Arduino language (which is based on C/C++) 
// to control a robot's movement. We'll use basic components such as motors and an Arduino board like
// the Arduino Uno to create a simple program that makes a robot move forward.


// Define motor pins
const int motorA1 = 3;  // Motor A forward
const int motorA2 = 4;  // Motor A backward
const int motorB1 = 5;  // Motor B forward
const int motorB2 = 6;  // Motor B backward

void setup() {
  // Set motor pins as output
  pinMode(motorA1, OUTPUT);
  pinMode(motorA2, OUTPUT);
  pinMode(motorB1, OUTPUT);
  pinMode(motorB2, OUTPUT);
  
  // Start motors in the stopped state
  stopMotors();
}

void loop() {
  // Move forward
  moveForward();
  delay(2000); // Move forward for 2 seconds

  // Stop
  stopMotors();
  delay(1000); // Stop for 1 second

  // Move backward
  moveBackward();
  delay(2000); // Move backward for 2 seconds

  // Stop
  stopMotors();
  delay(1000); // Stop for 1 second
}

// Function to move robot forward
void moveForward() {
  digitalWrite(motorA1, HIGH);
  digitalWrite(motorA2, LOW);
  digitalWrite(motorB1, HIGH);
  digitalWrite(motorB2, LOW);
}

// Function to move robot backward
void moveBackward() {
  digitalWrite(motorA1, LOW);
  digitalWrite(motorA2, HIGH);
  digitalWrite(motorB1, LOW);
  digitalWrite(motorB2, HIGH);
}

// Function to stop motors
void stopMotors() {
  digitalWrite(motorA1, LOW);
  digitalWrite(motorA2, LOW);
  digitalWrite(motorB1, LOW);
  digitalWrite(motorB2, LOW);
}
