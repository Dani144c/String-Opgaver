#! /usr/bin/python3

'''
This file contains Joystick example code for controlling PiArm
Developed by - SB Components
http://sb-components.co.uk

This project has been further optimized.
Refined by - Daniel Matthiesen & Lasse Hadberg
'''

import re
import pygame
import piarm
from time import sleep

class Joystick_Controller(object):
    """
    Joystick controller class
    """

    def __init__(self):
        self.servo_POS_error = False
        self.joystick_keypress_status = False
        '''
        self.step is used to define the value at which the servo will change its position.
        Increasing this will cause the position to change at larger intervals.
        This will in turn cause the controller to 'feel' less responsive.
        '''
        self.step = 5
        # This is used to define the initial position of the ARM.
        self.servo_position = {
                 1: 500,
                 2: 500,
                 3: 500,
                 4: 500,
                 5: 500,
                 6: 500,
            }
        # Button Status is used to tell wether a button is pressed or not.
        self.button_status = {
                     0: 0,
                     1: 0,
                     2: 0,
                     3: 0,
                     4: 0,
                     5: 0,
                     6: 0,
            }

        #  Initialize Joystick
        pygame.init()
        try:
            self.controller = pygame.joystick.Joystick(0)
            self.controller.init()
            print('Joystick initialized')
        except pygame.error as pygame_err:
            print(pygame_err)
        # This initial read of the servo positions allows us to determine if the positions are read successfully.
        self.read_servo_position()
        print(self.servo_position)

    def listen(self):
        """
        Listen for events to happen
        """
        while True:
            for event in pygame.event.get():
                #  Button Pressed
                if event.type == pygame.JOYBUTTONDOWN:
                    # set Servo to default - Start Button
                    if event.button == 9:
                        done = 0
                        servoid = 1
                        while done == 0:
                            print("Servo number {" + str(servoid) + "} has been reset to default")
                            self.servo_position[servoid] = 500
                            robot.servoWrite(servoid, self.servo_position[servoid], 500)
                            servoid = servoid+1
                            if servoid == 7:
                                done = 1
                        print("Alle Servoer er returneret til default position")
                        self.servo_position = {
                            1: 500,
                            2: 500,
                            3: 500,
                            4: 500,
                            5: 500,
                            6: 500,
                            }
                        '''
                        This sleep is necessary as the movement to default position takes 0.5 seconds.
                        If left out, changing the position prematurely is possible and can cause placement issues.
                        '''
                        sleep(0.5)

                    # keypress
                    elif event.button in range(13):
                        self.button_status[event.button] = 1
                        print('button {} pressed: '.format(event.button),
                                     self.button_status[event.button])
                    print(self.button_status)

                #  Button Released
                elif event.type == pygame.JOYBUTTONUP:
                    if event.button in range(13):
                        self.button_status[event.button] = 0
                        print('button {} released: '.format(event.button),
                                     self.button_status[event.button])

                #  If facing buttons are pressed reset button position
                if self.button_status[0] == self.button_status[2]:
                    self.button_status[0] = 0
                    self.button_status[2] = 0
                if self.button_status[1] == self.button_status[3]:
                    self.button_status[1] = 0
                    self.button_status[3] = 0

            # Change servo position
            '''
            As the state of button_status changes, the input from the controller will determine which
            'button' is pressed and as such which command to execute.
            '''
            for button, status in self.button_status.items():
                if status:
                    #  Move UP - Triangle
                    if button == 0:
                        if self.servo_position[5] - self.step in range(500,900):
                            self.servo_position[5] -= self.step
                        if self.servo_position[4] + self.step in range(215, 500):
                            self.servo_position[4] += (self.step + 10)
                        if self.servo_position[3] - self.step in range(500, 880):
                            self.servo_position[3] -= (self.step + 15)

                    #  Move Left - Square
                    elif button == 1:
                        if self.servo_position[6] + self.step in range(70, 900):
                            self.servo_position[6] += self.step * 10

                    #  Move Down - Cross
                    elif button == 2:
                        if self.servo_position[5] + self.step in range(500, 595):
                            self.servo_position[5] += self.step
                        if self.servo_position[4] - self.step in range(215, 500):
                            self.servo_position[4] -= (self.step + 10)
                        if self.servo_position[3] + self.step in range(500, 880):
                            self.servo_position[3] += (self.step + 15)

                    #  Move Right - Circle
                    elif button == 3:
                        if self.servo_position[6] - self.step in range(125, 951):
                            self.servo_position[6] -= self.step * 10

                    #  Claw Open - L1
                    elif button == 4:
                        if self.servo_position[1] - self.step in range(160, 800):
                            self.servo_position[1] -= (self.step * 15)

                    #  Claw Close - R1
                    elif button == 5:
                        if self.servo_position[1] + self.step in range(30, 710):
                            self.servo_position[1] += (self.step * 15)

                    #  Claw Left - L2
                    elif button == 6:
                        if self.servo_position[2] + self.step in range(125, 875):
                            self.servo_position[2] += (self.step * 15)

                    #  Claw Right - R2
                    elif button == 7:
                        if self.servo_position[2] - self.step in range(125, 875):
                            self.servo_position[2] -= (self.step * 15)

                    # Arm Retract Arm - R3
                    elif button == 10:
                        if self.servo_position[5] - self.step in range(500, 750):
                            self.servo_position[5] -= self.step
                        if self.servo_position[4] - self.step in range(215, 500):
                            self.servo_position[4] -= (self.step + 10)
                        if self.servo_position[3] + self.step in range(500, 880):
                            self.servo_position[3] += (self.step + 15)

                    # Arm Extend Arm - L3
                    elif button == 11:
                        if self.servo_position[5] + self.step in range(500, 750):
                            self.servo_position[5] += self.step
                        if self.servo_position[4] + self.step in range(215, 500):
                            self.servo_position[4] += (self.step + 10)
                        if self.servo_position[3] - self.step in range(500, 880):
                            self.servo_position[3] -= (self.step + 15)

                    # The keypress status is changed to true, this tells the program that it's time to move a servo.
                    self.joystick_keypress_status = True

            #  Write current positions
            if self.joystick_keypress_status:
                if robot.alive:
                    for ID in range(1, 7):
                        robot.servoWrite(ID, self.servo_position[ID], 250)
                        print("Writing to servo Id {} position: ".format(ID), self.servo_position[ID])
                    self.joystick_keypress_status = False
                else:
                    print('Comm port is not connected')
                '''
                # For a fluid movement, it's important that this sleep is synchronized with the
                movement timer for the servoWrite.
                '''
                sleep(0.25)

    def read_servo_position(self):
        '''
        This funciton read current servo position
        '''
        if robot.alive:
            try:
                #  Read Positions of motors one at a time
                for ID in range(1, 7):
                    done = 0
                    while done == 0:
                        postrue = 0
                        response = robot.positionRead(ID)

                        for element in response:
                            postrue = postrue + 1

                        if postrue >= 7:
                            pos = int.from_bytes(response[5]+response[6], byteorder='little')
                            #  Button Position to variable
                            self.servo_position[ID] = pos
                            done = 1


                if self.servo_POS_error:
                    print("Servo Error", "Servo " + str(ID) +
                                     ' - Position Out of Range..!')
                else:
                    print("Motor position Read Done Successfully")

            except TypeError:
                print("Servo Error", "Servo " + str(ID) +
                                     ' - Not Responding')

if __name__ == "__main__":
    robot = piarm.PiArm()
    # write your serial comm.
    robot.connect("/dev/ttyUSB0")
    joystick = Joystick_Controller()
    #  Start Joystick
    try:
        joystick.listen()
    #  Set Motors to Default at KeyboardInterrupt
    except KeyboardInterrupt:
        pass
        for ID in range(1, 7):
            robot.servoWrite(ID, 500, 1500)