/**
 * Definition for binary tree
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    vector<int> postorderTraversal(TreeNode *root)
	{
		vector<int> ans;
		vector<int> left;
		vector<int> right;
		
		if(root==NULL)
			return ans;
		left=postorderTraversal(root->left);
		right=postorderTraversal(root->right);
		if(left.size()!=0)
			ans.insert(ans.end(),left.begin(),left.end());
		if(right.size()!=0)
			ans.insert(ans.end(),right.begin(),right.end());
		ans.push_back(root->val);
		return ans;
	}
};