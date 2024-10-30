import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

# Set up the figure
fig = plt.figure(figsize=(14, 10))

# Cartesian Coordinate System - 3D Plot
ax1 = fig.add_subplot(221, projection='3d')
x = np.linspace(-5, 5, 10)
y = np.linspace(-5, 5, 10)
X, Y = np.meshgrid(x, y)
Z = np.zeros_like(X)

ax1.plot_surface(X, Y, Z, alpha=0.3, color='lightblue')
ax1.set_title('Cartesian Coordinate System (3D)')
ax1.set_xlabel('X-axis')
ax1.set_ylabel('Y-axis')
ax1.set_zlabel('Z-axis')

# Draw lines along the axes
ax1.quiver(0, 0, 0, 5, 0, 0, color='r', arrow_length_ratio=0.1)  # X-axis
ax1.quiver(0, 0, 0, 0, 5, 0, color='g', arrow_length_ratio=0.1)  # Y-axis
ax1.quiver(0, 0, 0, 0, 0, 5, color='b', arrow_length_ratio=0.1)  # Z-axis

# Polar Coordinate System - 2D Plot
ax2 = fig.add_subplot(222, polar=True)
theta = np.linspace(0, 2 * np.pi, 100)
r = np.abs(np.sin(3 * theta))  # Example of a polar function
ax2.plot(theta, r, color='purple')
ax2.set_title('Polar Coordinate System (2D)')

# Draw radial lines
for angle in np.linspace(0, 2 * np.pi, 12):
    ax2.plot([angle, angle], [0, 1], color='lightgrey', linestyle='--')

# Cylindrical Coordinate System - 3D Plot
ax3 = fig.add_subplot(223, projection='3d')
theta = np.linspace(0, 2 * np.pi, 100)
z = np.linspace(-5, 5, 100)
r = 3
X = r * np.cos(theta)
Y = r * np.sin(theta)
ax3.plot_surface(X, Y, z.reshape(-1, 1), alpha=0.3, color='orange')
ax3.set_title('Cylindrical Coordinate System (3D)')
ax3.set_xlabel('X-axis')
ax3.set_ylabel('Y-axis')
ax3.set_zlabel('Z-axis')

# Draw lines along the axes
ax3.quiver(0, 0, -5, 0, 0, 10, color='b', arrow_length_ratio=0.1)  # Z-axis
for t in np.linspace(0, 2 * np.pi, 12):
    ax3.quiver(0, 0, 0, 3 * np.cos(t), 3 * np.sin(t), 0, color='g', arrow_length_ratio=0.1)

# Spherical Coordinate System - 3D Plot
ax4 = fig.add_subplot(224, projection='3d')
phi = np.linspace(0, np.pi, 50)  # Polar angle
theta = np.linspace(0, 2 * np.pi, 50)  # Azimuthal angle
phi, theta = np.meshgrid(phi, theta)
r = 4
X = r * np.sin(phi) * np.cos(theta)
Y = r * np.sin(phi) * np.sin(theta)
Z = r * np.cos(phi)
ax4.plot_surface(X, Y, Z, alpha=0.3, color='green')
ax4.set_title('Spherical Coordinate System (3D)')
ax4.set_xlabel('X-axis')
ax4.set_ylabel('Y-axis')
ax4.set_zlabel('Z-axis')

# Draw lines along the axes
ax4.quiver(0, 0, 0, 0, 0, 4, color='b', arrow_length_ratio=0.1)  # Z-axis
ax4.quiver(0, 0, 0, 4, 0, 0, color='r', arrow_length_ratio=0.1)  # X-axis
ax4.quiver(0, 0, 0, 0, 4, 0, color='g', arrow_length_ratio=0.1)  # Y-axis

plt.tight_layout()
plt.show()
