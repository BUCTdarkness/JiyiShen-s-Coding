//#pragma comment(linker, "/STACK:36777216")
#include <functional>
#include <algorithm>
#include <iostream>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <numeric>
#include <cstring>
#include <climits>
#include <cassert>
#include <complex>
#include <cstdio>
#include <string>
#include <vector>
#include <bitset>
#include <queue>
#include <stack>
#include <cmath>
#include <ctime>
#include <list>
#include <set>
#include <map>
using namespace std;
#define CLR(A) memset(A,0,sizeof(A))
#define CPY(A,B) memcpy(A,B,sizeof(B))
set<int> p,q;
int main(){
    int n;
    while(~scanf("%d",&n)){
        p.clear();q.clear();
        int v;
        for(int i=0;i<n;i++){
            scanf("%d",&v);
            p.insert(v);
        }
        for(int i=0;i<n;i++){
            scanf("%d",&v);
            q.insert(v);
        }
        if(p!=q) puts("NO");
        else puts("YES");
    }
    return 0;
}

