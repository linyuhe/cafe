﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.UnionFind
{
    public class QuickUnionWithCompression: UnionFind
    {
        private int count;

        private int[] rank;

        private int[] parents;

        public QuickUnionWithCompression(int count)
        {
            this.count = count;
            this.parents = new int[count];
            this.rank = new int[count];
            for (int i = 0; i < count; i++)
            {
                parents[i] = i;
                rank[i] = 1;
            }
        }

        public int find(int p)
        {
            Trace.Assert(p >= 0 && p < count);
            while(p != parents[p])
            {
                parents[p] = parents[parents[p]];
                p = parents[p];
            }
            return p;
            /*
            if(p != parents[p])
            {
                parents[p] = find(parents[p]);
            }
            return parents[p];
            */
        }

        public bool isConnected(int p, int q)
        {
            return find(p) == find(q);
        }

        public void union(int p, int q)
        {
            int pRoot = find(p);
            int qRoot = find(q);

            if(pRoot != qRoot)
            {
                if(rank[pRoot] > rank[qRoot])
                {
                    parents[qRoot] = pRoot;
                }else if (rank[pRoot] < rank[qRoot])
                {
                    parents[pRoot] = qRoot;
                }else
                {
                    parents[pRoot] = qRoot;
                    rank[qRoot]++;
                }
            }
        }
    }
}
