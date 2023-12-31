import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Category } from "../_models/category";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) {

    }

    public addCategory(category: Category) {
        return this.http.post(this.baseUrl + 'Categories', category);
    }

    public updateCategory(id: number, category: Category) {
        return this.http.put(this.baseUrl + 'Categories/' + id, category);
    }

    public getCategories(): Observable<Category[]> {
        return this.http.get<Category[]>(this.baseUrl + `Categories`);
    }

    public deleteCategory(id: number) {
        return this.http.delete(this.baseUrl + 'Categories/' + id);
    }

    public getCategoryById(id: number): Observable<Category> {
        return this.http.get<Category>(this.baseUrl + 'Categories/' + id);
    }

    public search(name: string): Observable<Category[]> {
        return this.http.get<Category[]>(`${this.baseUrl}Categories/search/${name}`);
    }
}