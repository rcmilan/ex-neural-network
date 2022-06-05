open Types.NeuronTypes
open Functions.NeuronMath

printfn "=============================="
printfn "NEURAL NETWORK FROM SCRATCH!!!"

let inputs : Inputs seq = [|
        [| 1.0; 2.0; 3.0; 2.5 |];
        [|2.0; 5.0; -1.0; 2.0|];
        [|-1.5; 2.7; 3.3; -0.8|]
    |]

let weightsSeq : Weights seq = [|
        [|0.2; 0.8; -0.5; 1.0|];
        [|0.5; -0.91; 0.26; -0.5|];
        [|-0.26; -0.27; 0.17; 0.87|]
    |]

let bias : Bias seq = [| 2.0; 3.0; 0.5 |]

let dotProducts = dot<DotProduct seq seq> weightsSeq inputs

printfn "RESULTADO DA CAMADA!!!"
for dotProduct in dotProducts do
    Seq.iter (printf "\t%A") (dotWithBias dotProduct bias)
    printf "\n"

System.Console.ReadKey() |> ignore