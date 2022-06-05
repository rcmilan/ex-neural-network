namespace Functions

module NeuronMath = 

    open Types.NeuronTypes

    let dotWithBias (dotProducts: DotProduct seq) (bias : Bias seq) = 
        Seq.map2 (+) dotProducts bias 

    let dot (weightSequence : Weights seq) (inputs : Inputs) : DotProduct seq =

        let dot (weight : Weights) (input : Inputs) = Seq.fold2 (fun state i w -> state + i * w) LanguagePrimitives.GenericZero input weight
    
        weightSequence |> Seq.map(fun weights -> dot weights inputs)

