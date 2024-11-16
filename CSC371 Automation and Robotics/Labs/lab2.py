# import numpy as np
# import matplotlib.pyplot as plt
# from matplotlib.animation import FuncAnimation

# # Forward Kinematics function: Compute the end-effector position based on joint angles
# def forward_kinematics(L1, L2, theta1, theta2):
#     # Link 1 position (x1, y1) relative to the base
#     x1 = L1 * np.cos(theta1)
#     y1 = L1 * np.sin(theta1)
    
#     # Link 2 position (x2, y2) relative to the end of Link 1
#     x2 = x1 + L2 * np.cos(theta1 + theta2)  # Applying angle θ1 + θ2 for the second joint
#     y2 = y1 + L2 * np.sin(theta1 + theta2)  # Apply angle θ1 + θ2 for the second joint
    
#     return (x2, y2)  # Return the position of the end-effector

# # Visualization function: Plot the robotic arm and animate its movement
# def plot_manipulator(L1, L2, theta1_range, theta2_range):
#     # Create a figure and axis for plotting
#     fig, ax = plt.subplots(figsize=(6,6))
#     ax.set_xlim(-L1-L2-1, L1+L2+1)
#     ax.set_ylim(-L1-L2-1, L1+L2+1)
#     ax.axhline(0, color='black',linewidth=1)  # X-axis
#     ax.axvline(0, color='black',linewidth=1)  # Y-axis
#     ax.set_aspect('equal', adjustable='box')
#     ax.grid(True)
    
#     # Initialize line and scatter for plotting links and joints
#     link1_line, = ax.plot([], [], label="Link 1", color="blue", lw=6)
#     link2_line, = ax.plot([], [], label="Link 2", color="red", lw=6)
#     joints = ax.scatter([], [], color="black")  # Plot joints
#     end_effector = ax.scatter([], [], color="green", s=100, zorder=5, label="End-Effector")
    
#     # Function to update the plot at each frame (used by FuncAnimation)
#     def update(frame):
#         # Generate joint angles from the ranges (animate)
#         theta1 = np.radians(theta1_range[frame])  # Convert degrees to radians
#         theta2 = np.radians(theta2_range[frame])  # Convert degrees to radians
        
#         # Compute the end-effector position using forward kinematics
#         x2, y2 = forward_kinematics(L1, L2, theta1, theta2)
        
#         # Update link 1: from base to joint 1 (x1, y1)
#         x1 = L1 * np.cos(theta1)
#         y1 = L1 * np.sin(theta1)
#         link1_line.set_data([0, x1], [0, y1])  # Update the first link
        
#         # Update link 2: from joint 1 to end-effector (x2, y2)
#         link2_line.set_data([x1, x2], [y1, y2])  # Update the second link
        
#         # Update joint positions (base, joint 1, end-effector)
#         joints.set_offsets([[0, 0], [x1, y1], [x2, y2]])  # Positions of joints and end-effector
        
#         # Update end-effector position
#         end_effector.set_offsets([x2, y2])  # Update the green end-effector dot
        
#         return link1_line, link2_line, joints, end_effector  # Return updated elements for animation

#     # Create an animation
#     ani = FuncAnimation(fig, update, frames=len(theta1_range), interval=100, blit=True)

#     # Show the animation
#     plt.legend()
#     plt.title("Robotic Arm Animation")
#     plt.xlabel("X axis")
#     plt.ylabel("Y axis")
#     plt.show()

# # Example usage:
# L1 = 5  # Length of the first link
# L2 = 4  # Length of the second link

# # Ranges of joint angles for animation (in degrees)
# theta1_range = np.linspace(0, 180, 50)  # Varying angle θ1 from 0° to 180°
# theta2_range = np.linspace(0, 90, 50)   # Varying angle θ2 from 0° to 90°

# # Call the function to visualize the animation
# plot_manipulator(L1, L2, theta1_range, theta2_range)


import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Forward Kinematics function: Computes the end-effector position based on joint angles
def forward_kinematics(L1, L2, theta1, theta2):
    """
    Given:
    - L1, L2: lengths of the two links
    - theta1: angle of the first joint in radians
    - theta2: angle of the second joint in radians

    The function calculates the position of each joint based on the angles using Forward Kinematics.
    Forward Kinematics is the process of finding the position of the end-effector in a robotic manipulator
    based on given joint angles and link lengths.
    
    Mathematical Steps:
    1. Compute the (x1, y1) position of the first joint relative to the base:
       x1 = L1 * cos(theta1)
       y1 = L1 * sin(theta1)

    2. Compute the (x2, y2) position of the end-effector by adding the coordinates of Link 2 to Link 1.
       Here, θ1 + θ2 gives the total rotation angle up to the end-effector:
       x2 = x1 + L2 * cos(theta1 + theta2)
       y2 = y1 + L2 * sin(theta1 + theta2)
    """
    
    # Compute the position of the first joint (x1, y1) relative to the base
    x1 = L1 * np.cos(theta1)
    y1 = L1 * np.sin(theta1)
    print(f"Joint 1 position (x1, y1): ({x1:.2f}, {y1:.2f})")
    
    # Compute the position of the end-effector (x2, y2) relative to the base
    x2 = x1 + L2 * np.cos(theta1 + theta2)
    y2 = y1 + L2 * np.sin(theta1 + theta2)
    print(f"End-effector position (x2, y2): ({x2:.2f}, {y2:.2f})")
    
    return (x2, y2)  # Return the position of the end-effector

# Visualization function: Plot the robotic arm and animate its movement
def plot_manipulator(L1, L2, theta1_range, theta2_range):
    """
    This function visualizes the 2-link manipulator as an animated plot.

    Given:
    - L1, L2: lengths of the two links
    - theta1_range: a range of angles for the first joint in degrees (for animation)
    - theta2_range: a range of angles for the second joint in degrees (for animation)

    Mathematical Explanation of the Animation Update:
    1. Each frame updates the joint angles θ1 and θ2 to move the manipulator.
    2. Using the Forward Kinematics function, it calculates:
       - The (x1, y1) position for the first joint
       - The (x2, y2) position for the end-effector
    3. These coordinates are then plotted as two segments (links) and updated each frame to create the animation.
    """
    
    # Create a figure and axis for plotting
    fig, ax = plt.subplots(figsize=(6,6))
    ax.set_xlim(-L1-L2-1, L1+L2+1)
    ax.set_ylim(-L1-L2-1, L1+L2+1)
    ax.axhline(0, color='black', linewidth=1)  # X-axis
    ax.axvline(0, color='black', linewidth=1)  # Y-axis
    ax.set_aspect('equal', adjustable='box')
    ax.grid(True)
    
    # Initialize line and scatter for plotting links and joints
    link1_line, = ax.plot([], [], label="Link 1", color="blue", lw=6)
    link2_line, = ax.plot([], [], label="Link 2", color="red", lw=6)
    joints = ax.scatter([], [], color="black")  # Plot joints
    end_effector = ax.scatter([], [], color="green", s=100, zorder=5, label="End-Effector")
    
    # Function to update the plot at each frame (used by FuncAnimation)
    def update(frame):
        """
        Update function for each animation frame.

        - frame: the index of the frame, which determines the angles for θ1 and θ2 at each step.
        - This function recalculates the joint positions and updates the line positions
          to simulate the movement of the manipulator.
        """

        # Generate joint angles from the ranges (animate)
        theta1 = np.radians(theta1_range[frame])  # Convert θ1 from degrees to radians
        theta2 = np.radians(theta2_range[frame])  # Convert θ2 from degrees to radians
        print(f"\nFrame {frame + 1}: θ1 = {np.degrees(theta1):.2f}°, θ2 = {np.degrees(theta2):.2f}°")

        # Compute the end-effector position using forward kinematics
        x2, y2 = forward_kinematics(L1, L2, theta1, theta2)
        
        # Update link 1: from base to joint 1 (x1, y1)
        x1 = L1 * np.cos(theta1)  # x1 is calculated using θ1
        y1 = L1 * np.sin(theta1)  # y1 is calculated using θ1
        link1_line.set_data([0, x1], [0, y1])  # Update the first link
        print(f"Link 1: [0, {x1:.2f}], [0, {y1:.2f}]")
        
        # Update link 2: from joint 1 to end-effector (x2, y2)
        link2_line.set_data([x1, x2], [y1, y2])  # Update the second link
        print(f"Link 2: [{x1:.2f}, {x2:.2f}], [{y1:.2f}, {y2:.2f}]")
        
        # Update joint positions (base, joint 1, end-effector)
        joints.set_offsets([[0, 0], [x1, y1], [x2, y2]])  # Positions of joints and end-effector
        
        # Update end-effector position
        end_effector.set_offsets([x2, y2])  # Update the green end-effector dot
        
        return link1_line, link2_line, joints, end_effector  # Return updated elements for animation

    # Create an animation
    ani = FuncAnimation(fig, update, frames=len(theta1_range), interval=100, blit=True)

    # Show the animation
    plt.legend()
    plt.title("Robotic Arm Animation")
    plt.xlabel("X axis")
    plt.ylabel("Y axis")
    plt.show()

# Example usage:
L1 = 5  # Length of the first link
L2 = 4  # Length of the second link

# Ranges of joint angles for animation (in degrees)
theta1_range = np.linspace(0, 180, 50)  # Varying angle θ1 from 0° to 180°
theta2_range = np.linspace(0, 90, 50)   # Varying angle θ2 from 0° to 90°

# Call the function to visualize the animation
plot_manipulator(L1, L2, theta1_range, theta2_range)
