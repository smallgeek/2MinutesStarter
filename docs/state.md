```mermaid
stateDiagram-v2
    input: 入力待ち
    2m: 2分計測中
    ne: 継続判断
    state if_ne <<choice>>
    con: 継続する
    stop: 中断する
    work: 作業中
    lock: 画面ロック
    return: ロック解除

    [*] --> input
    input --> [*]
    input --> 2m 
    2m --> ne
    ne --> if_ne
    if_ne --> con
    if_ne --> stop
    stop --> input
    con --> work
    work --> lock
    lock --> return
    return --> input
