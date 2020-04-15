REZULTATAI
===


Performance using List<T>
1000     - 45ms
10000    - 53ms
100000   - 307ms
1000000  - 2952ms
10000000 - 28910ms

Performance using LinkedList<T>
1000     - 50ms
10000    - 54ms
100000   - 387ms
1000000  - 3046ms
10000000 - 31844ms

Performance using Queue<T>
1000     - 40ms
10000    - 53ms
100000   - 311ms
1000000  - 2863ms
10000000 - 28785ms

atliekant eksperimentus greičio paklaida 5~100ms priklausomai nuo dyždio

Iš rezultatu yra matoma, jog eant nedideliam kiekiui duomenų, greitis nesiskiria. Tačiau didėjant kiekiui Queue<T> rodo 5~15% geresmius rezultatus nei List<T> ar LinkedList<T>
