// open Functions.NeuronMath

open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra

// Matrix + Vector operation
let inline (+) (m : Matrix<'a>) (v : Vector<'a>) = Matrix.mapRows (fun _ row -> row + v) m

let gauss = Distributions.Normal(Random.SystemRandomSource.Default)

type LayerDense(nInputs : int, nNeurons : int) = 
    let weights: Matrix<float> = 0.1 * DenseMatrix.random nInputs nNeurons gauss
    let biases:  Vector<float> = DenseVector.zero nNeurons

    member _.Forward inputs = 
        inputs * weights + biases
        
printfn "=============================="
printfn "NEURAL NETWORK FROM SCRATCH!!!"

let layer1 = LayerDense(4, 5)
let layer2 = LayerDense(5, 2)

let X = matrix [ // Input
        [ 1.0; 2.0; 3.0; 2.5 ];
        [2.0; 5.0; -1.0; 2.0];
        [-1.5; 2.7; 3.3; -0.8]
    ]

printfn "%A" (layer2.Forward << layer1.Forward <| X)

// let X : seq<float> seq = [| // Input
//         [| 1.0; 2.0; 3.0; 2.5 |];
//         [|2.0; 5.0; -1.0; 2.0|];
//         [|-1.5; 2.7; 3.3; -0.8|]
//     |]

// let weightsSeq : seq<float> seq = [|
//         [|0.2; 0.8; -0.5; 1.0|];
//         [|0.5; -0.91; 0.26; -0.5|];
//         [|-0.26; -0.27; 0.17; 0.87|]
//     |]

// let bias : seq<float> = [| 2.0; 3.0; 0.5 |]

// let weightsSeq2 : seq<float> seq = [|
//         [|0.1; -0.14; 0.5;|];
//         [|-0.5; 0.12; -0.33;|];
//         [|-0.44; 0.73; -0.13;|]
//     |]

// let bias2 : seq<float> = [| -1.0; 2.0; -0.5 |]

// let result = dot<float seq seq> weightsSeq X
//                 |> Seq.map(fun f -> applyBias f bias) // Resultado da camada 1
//                 |> dot<float seq seq> weightsSeq2
//                 |> Seq.map(fun f -> applyBias f bias2) // Resultado da camada 2

// for dotProductWithBias in result do 
//     for res in dotProductWithBias do
//         printf "%A\t" res
//     printf "\n"

System.Console.ReadKey() |> ignore