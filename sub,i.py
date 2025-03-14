%run "readonly/BackpropModule.ipynb"# PACKAGE
import numpy as np
import matplotlib.pyplot as plt# PACKAGE
# First load the worksheet dependencies.
# Here is the activation function and its derivative.
sigma = lambda z : 1 / (1 + np.exp(-z))
d_sigma = lambda z : np.cosh(z/2)**(-2) / 4

# This function initialises the network with it's structure, it also resets any training already done.
def reset_network (n1 = 6, n2 = 7, random=np.random) :
    global W1, W2, W3, b1, b2, b3
    W1 = random.randn(n1, 1) / 2
    W2 = random.randn(n2, n1) / 2
    W3 = random.randn(2, n2) / 2
    b1 = random.randn(n1, 1) / 2
    b2 = random.randn(n2, 1) / 2
    b3 = random.randn(2, 1) / 2

# This function feeds forward each activation to the next layer. It returns all weighted sums and activations.
def network_function(a0) :
    z1 = W1 @ a0 + b1
    a1 = sigma(z1)
    z2 = W2 @ a1 + b2
    a2 = sigma(z2)
    z3 = W3 @ a2 + b3
    a3 = sigma(z3)
    return a0, z1, a1, z2, a2, z3, a3

# This is the cost function of a neural network with respect to a training set.
def cost(x, y) :
    return np.linalg.norm(network_function(x)[-1] - y)**2 / x.size# GRADED FUNCTION

# Jacobian for the third layer weights. There is no need to edit this function.
def J_W3 (x, y) :
    # First get all the activations and weighted sums at each layer of the network.
    a0, z1, a1, z2, a2, z3, a3 = network_function(x)
    # We'll use the variable J to store parts of our result as we go along, updating it in each line.
    # Firstly, we calculate dC/da3, using the expressions above.
    J = 2 * (a3 - y)
    # Next multiply the result we've calculated by the derivative of sigma, evaluated at z3.
    J = J * d_sigma(z3)
    # Then we take the dot product (along the axis that holds the training examples) with the final partial derivative,
    # i.e. dz3/dW3 = a2
    # and divide by the number of training examples, for the average over all training examples.
    J = J @ a2.T / x.size
    # Finally return the result out of the function.
    return J


def J_b3 (x, y) :
    # As last time, we'll first set up the activations.
    a0, z1, a1, z2, a2, z3, a3 = network_function(x)
    
    # ===COPY TWO LINES FROM THE PREVIOUS FUNCTION TO SET UP THE FIRST TWO JACOBIAN TERMS===
    J = 2 * (a3 - y)  # Calculate dC/da3
    J = J * d_sigma(z3)  # Multiply by d(a3)/dz3
    
    # For the final line, we don't need to multiply by dz3/db3, because that is multiplying by 1.
    # We still need to sum over all training examples however.
    J = np.sum(J, axis=1, keepdims=True) / x.size  # Sum over all examples and normalize
    
    return J# GRADED FUNCTION

# Compare this function to J_W3 to see how it changes.
# There is no need to edit this function.
def J_W2 (x, y) :
    #The first two lines are identical to in J_W3.
    a0, z1, a1, z2, a2, z3, a3 = network_function(x)    
    J = 2 * (a3 - y)
    # the next two lines implement da3/da2, first σ' and then W3.
    J = J * d_sigma(z3)
    J = (J.T @ W3).T
    # then the final lines are the same as in J_W3 but with the layer number bumped down.
    J = J * d_sigma(z2)
    J = J @ a1.T / x.size
    return J

def J_b2(x, y):
    # Step 1: Set up the activations
    a0, z1, a1, z2, a2, z3, a3 = network_function(x)

    # Step 2: ∂C/∂a3 - Difference between prediction and true value
    J = 2 * (a3 - y)

    # Step 3: ∂a3/∂a2 = ∂a3/∂z3 * ∂z3/∂a2
    J = J * d_sigma(z3)  # ∂a3/∂z3 (activation derivative)
    J = (J.T @ W3).T     # ∂z3/∂a2 (weights of Layer 3)

    # Step 4: ∂a2/∂z2 (activation derivative for Layer 2)
    J = J * d_sigma(z2)

    # Step 5: ∂z2/∂b2 = 1 (bias derivative)
    J = np.sum(J, axis=1, keepdims=True) / x.size  # Sum over all examples

    return J
def J_W1(x, y):
    a0, z1, a1, z2, a2, z3, a3 = network_function(x)
    
    # First calculate ∂C/∂a(3)
    J = 2 * (a3 - y)
    
    # Then compute ∂a(3)/∂a(2) as σ'(z(3)) * W(3)
    J = J * d_sigma(z3)
    J = (J.T @ W3).T  # Matrix multiplication with W3
    
    # Now calculate ∂a(2)/∂a(1) as σ'(z(2)) * W(2)
    J = J * d_sigma(z2)
    J = (J.T @ W2).T  # Matrix multiplication with W2
    
    # Now calculate ∂a(1)/∂z(1) as σ'(z(1))
    J = J * d_sigma(z1)
    
    # Finally, calculate ∂z(1)/∂W(1) as a0 (input) and average over training examples
    J = J @ a0.T / x.size
    
    return J

def J_b1(x, y):
    a0, z1, a1, z2, a2, z3, a3 = network_function(x)
    
    # First calculate ∂C/∂a(3)
    J = 2 * (a3 - y)
    
    # Then compute ∂a(3)/∂a(2) as σ'(z(3)) * W(3)
    J = J * d_sigma(z3)
    J = (J.T @ W3).T  # Matrix multiplication with W3
    
    # Now calculate ∂a(2)/∂a(1) as σ'(z(2)) * W(2)
    J = J * d_sigma(z2)
    J = (J.T @ W2).T  # Matrix multiplication with W2
    
    # Now calculate ∂a(1)/∂z(1) as σ'(z(1))
    J = J * d_sigma(z1)
    
    # Finally, sum over all training examples for the bias and average
    J = np.sum(J, axis=1, keepdims=True) / x.size
    
    return J

J_W1(x, y)
J_b1(x, y)

print(J_W1)
print(J_b1)x, y = training_data()
reset_network()plot_training(x, y, iterations=10000, aggression=7, noise=1)