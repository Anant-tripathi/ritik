#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

struct tree
{
    int value, h;
    struct tree *left, *right, *p;
} *root = NULL;

int max(int a, int b)
{
    return ((a > b) ? a : b);
}

int maxh(struct tree *a)
{
    if (a->left == NULL && a->right == NULL)
        return a->h;
    else if (a->left == NULL)
        return maxh(a->right);
    else if (a->right == NULL)
        return maxh(a->left);
    else
        return max(maxh(a->left), maxh(a->right));
}

int bal(struct tree *a)
{
    int left, right;
    if (a->left == NULL)
        left = a->h;
    else
        left = maxh(a->left);
    if (a->right == NULL)
        right = a->h;
    else
        right = maxh(a->right);
    return left - right;
}

void ll(struct tree *a)
{
}

void add(struct tree *a, struct tree *ptr)
{
    if (a->value > ptr->value)
    {
        if (ptr->right == NULL)
        {
            ptr->right = a;
            a->h = ptr->h + 1;
            a->p = ptr;
            return;
        }
        else
        {
            add(a, ptr->right);
            if (bal(ptr) < -1 && ptr->right->val < a->val)
                rr(ptr);
            else
                rl(ptr);
        }
    }
    if (a->value < ptr->value)
        if (ptr->left == NULL)
        {
            ptr->left = a;
            a->h = ptr->h + 1;
            a->p = ptr;
        }
        else
        {
            add(a, ptr->left);
            if (bal(ptr) > 1 && ptr->right->val > a->val)
                ll(ptr);
            else
                lr(ptr);
        }
}

void createtree(int a)
{
    struct tree *new = (struct tree *)malloc(sizeof(struct tree));
    new->left = NULL;
    new->right = NULL;
    new->value = a;
    new->h = 0;
    if (root == NULL)
        root = new;
    else
        add(new, root);
}

void inorder(struct tree *a)
{
    if (a == NULL)
        return;
    inorder(a->left);
    printf("%d,%d ", a->value, a->h);
    inorder(a->right);
}

void preorder(struct tree *a)
{
    if (a == NULL)
        return;
    printf("%d ", a->value);
    preorder(a->left);
    preorder(a->right);
}

void postorder(struct tree *a)
{
    if (a == NULL)
        return;
    postorder(a->left);
    postorder(a->right);
    printf("%d ", a->value);
}

int search(struct tree *r, int x)
{
    if (r == NULL)
        return 0;
    else if (r->value == x)
        return 1;
    else if (r->value < x)
        return search(r->right, x);
    else
        return search(r->left, x);
}

int min(struct tree *r)
{
    struct tree *tmp = r;
    while (tmp && tmp->left != NULL)
        tmp = tmp->left;
    return tmp->value;
}

struct tree *del(struct tree *r, int x)
{
    if (r == NULL)
        return r;
    else if (r->value > x)
        r->left = del(r->left, x);
    else if (r->value < x)
        r->right = del(r->right, x);
    else
    {
        if (r->left == NULL)
        {
            struct tree *tmp = r->right;
            free(r);
            return tmp;
        }
        else if (r->right == NULL)
        {
            struct tree *tmp = r->left;
            free(r);
            return tmp;
        }
        else
        {
            r->value = min(r->right);
            r->right = del(r->right, r->value);
        }
    }
    return r;
}

void main()
{
    while (1)
    {
        int ch, a;
        printf("Menu:\n\n1.Enter Node\n2.Inorder\n3.Preorder\n4.Postorder\n5.Search\n6.Delete\n7.Exit\n\nEnter Choice: ");
        scanf("%d", &ch);
        switch (ch)
        {
        case 1:
            printf("Enter Value: ");
            scanf("%d", &a);
            createtree(a);
            printf("\n%d added to the Tree", a);
            break;
        case 2:
            printf("Inorder: ");
            inorder(root);
            break;
        case 3:
            printf("\nPreorder: ");
            preorder(root);
            break;
        case 4:
            printf("\nPostorder: ");
            postorder(root);
            break;
        case 5:
            int flag = 0;
            printf("Enter Value to be searched: ");
            scanf("%d", &a);
            flag = search(root, a);
            if (flag == 1)
                printf("%d found in tree", a);
            else
                printf("%d not found in tree", a);
            break;
        case 6:
            printf("Enter Value to be deleted: ");
            scanf("%d", &a);
            root = del(root, a);
            break;
        case 7:
            exit(0);
        default:
            printf("Invalid choice. Try again.");
        }
        getch();
        printf("\e[1;1H\e[2J");
    }
}