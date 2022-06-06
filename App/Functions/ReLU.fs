namespace Functions

module Activation = 
    open MathNet.Numerics.LinearAlgebra

    type ReLU()= 
        static member Forward = Matrix.map (max 0.0)