import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Link lengths
l1 = 2  # Length of the first link
l2 = 1  # Length of the second link

# Target position
target_x = 2.5
target_y = 1.5

# PID controller gains
Kp = 2.0
Kd = 1.0
Ki = 0.0

# Time settings
dt = 0.1  # Time step
total_time = 10  # Total animation time
iterations = int(total_time / dt)

# Initial angles
theta1 = 0.0
theta2 = 0.0

# Error terms for PID
error_sum = 0
prev_error = 0

# Store angles for plotting
theta1_list = []
theta2_list = []

# Inverse Kinematics function
def inverse_kinematics(x, y):
    cos_theta2 = (x**2 + y**2 - l1**2 - l2**2) / (2 * l1 * l2)
    theta2 = np.arccos(np.clip(cos_theta2, -1.0, 1.0))
    sin_theta2 = np.sin(theta2)
    
    k1 = l1 + l2 * cos_theta2
    k2 = l2 * sin_theta2

    theta1 = np.arctan2(y, x) - np.arctan2(k2, k1)
    
    return theta1, theta2

# Forward Kinematics function
def forward_kinematics(theta1, theta2):
    x = l1 * np.cos(theta1) + l2 * np.cos(theta1 + theta2)
    y = l1 * np.sin(theta1) + l2 * np.sin(theta1 + theta2)
    return x, y

# Animation setup
fig, ax = plt.subplots()
ax.set_xlim(-4, 4)
ax.set_ylim(-4, 4)
line, = ax.plot([], [], 'o-', lw=2)
target_point, = ax.plot(target_x, target_y, 'rx')

# Initialize plot
def init():
    line.set_data([], [])
    return line,

# Update function for animation
def update(frame):
    global theta1, theta2, error_sum, prev_error

    # Calculate desired joint angles using inverse kinematics
    desired_theta1, desired_theta2 = inverse_kinematics(target_x, target_y)

    # PID control for theta1
    error1 = desired_theta1 - theta1
    error_sum += error1 * dt
    d_error1 = (error1 - prev_error) / dt
    control1 = Kp * error1 + Ki * error_sum + Kd * d_error1
    theta1 += control1 * dt
    prev_error = error1

    # PID control for theta2
    error2 = desired_theta2 - theta2
    d_error2 = (error2 - prev_error) / dt
    control2 = Kp * error2 + Ki * error_sum + Kd * d_error2
    theta2 += control2 * dt

    # Forward kinematics to get end-effector position
    x1 = l1 * np.cos(theta1)
    y1 = l1 * np.sin(theta1)
    x2 = x1 + l2 * np.cos(theta1 + theta2)
    y2 = y1 + l2 * np.sin(theta1 + theta2)

    # Update plot
    line.set_data([0, x1, x2], [0, y1, y2])
    return line,

# Create animation
ani = FuncAnimation(fig, update, frames=iterations, init_func=init, blit=True, interval=dt*10000)

# Display animation
plt.xlabel("X-axis")
plt.ylabel("Y-axis")
plt.title("2-Link Robot Arm Motion Control with PID")
plt.grid()
plt.show()


# This simple example demonstrates how inverse kinematics and PID control can be combined to achieve precise motion in robotic systems.