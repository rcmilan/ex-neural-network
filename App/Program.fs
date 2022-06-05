open Types.NeuronTypes
open Functions.NeuronMath

printfn "=============================="
printfn "NEURAL NETWORK FROM SCRATCH!!!"

let inputs : Inputs = [| 1.0; 2.0; 3.0; 2.5 |]

let weightsSeq : Weights seq = [|
        [|0.2; 0.8; -0.5; 1.0|];
        [|0.5; -0.91; 0.26; -0.5|];
        [|-0.26; -0.27; 0.17; 0.87|]
    |]

let bias : Bias seq = [| 2.0; 3.0; 0.5 |]

let dps = (dot weightsSeq inputs) 

printfn "RESULTADO DA CAMADA!!!"
Seq.iter (printfn "\t%A") (dotWithBias dps bias)

System.Console.ReadKey() |> ignore