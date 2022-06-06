namespace Layers

module private Matrix =

    open MathNet.Numerics.LinearAlgebra

    // Matrix + Vector Fun ao invés de operator
    let AddVectorToEachRow(m : Matrix<float>) (v : Vector<float>) = Matrix.mapRows (fun _ row -> row + v) m


module Dense = 
    open MathNet.Numerics
    open MathNet.Numerics.LinearAlgebra

    // Matrix + Vector operator
    //let inline (+) (m : Matrix<'a>) (v : Vector<'a>) = Matrix.mapRows (fun _ row -> row + v) m
    
    let gauss = Distributions.Normal(Random.SystemRandomSource.Default)

    type LayerDense(nInputs : int, nNeurons : int) = 
        let weights: Matrix<float> = 0.1 * DenseMatrix.random nInputs nNeurons gauss
        let biases:  Vector<float> = DenseVector.zero nNeurons

        //member _.Forward inputs = 
        //    inputs * weights + biases // operator
        
        member _.Forward inputs = 
            Matrix.AddVectorToEachRow (inputs * weights) biases // fun
