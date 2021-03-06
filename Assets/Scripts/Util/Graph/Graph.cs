﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{
    /// <summary>
    /// Граф
    /// </summary>
    /// <typeparam name="T">Тип имени вершин</typeparam>
    public class Graph<T>
    {
        private List<Vertex<T>> _vertices;

        /// <summary>
        /// Создать пустой граф
        /// </summary>
        public Graph()
        {
            _vertices = new List<Vertex<T>>();
        }

        /// <summary>
        /// Создать граф с вершинами
        /// </summary>
        /// <param name="vertices">Вершины</param>
        public Graph(List<Vertex<T>> vertices)
        {
            _vertices = vertices;
        }

        /// <summary>
        /// Создать вершину
        /// </summary>
        /// <param name="name">Имя вершины</param>
        public void AddVertex(T name)
        {
            if (FindVertex(name) == null) _vertices.Add(new Vertex<T>(name));
        }

        /// <summary>
        /// Добавить неориентированое ребро
        /// </summary>
        /// <param name="start">Стартовая вершины</param>
        /// <param name="finish">Конечная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public void AddUndirectedEdge(T start, T finish, int weight)
        {
            AddDirectedEdge(start, finish, weight);
            AddDirectedEdge(finish, start, weight);
        }

        /// <summary>
        /// Добавить ориентированое ребро
        /// </summary>
        /// <param name="start">Стартова вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public void AddDirectedEdge(T start, T finish, int weight)
        {
            var startVertex = GetVertex(start);
            var finishVertex = GetVertex(finish);

            startVertex.AddEdge(finishVertex, weight);
        }

        /// <summary>
        /// Поиск вершины
        /// </summary>
        /// <param name="soughtVertex">Искомая вершина</param>
        /// <returns>Если вершина с именем пресутсвует то вернуть ее</returns>
        public Vertex<T> FindVertex(T soughtVertex)
        {
            return _vertices.Find(v => v.Name.Equals(soughtVertex));
        }

        /// <summary>
        /// Получить вершину
        /// </summary>
        /// <param name="name">Имя вершины</param>
        /// <returns>Вершина</returns>
        public Vertex<T> GetVertex(T name)
        {
            var vertex = _vertices.Find(v => v.Name.Equals(name));

            if (vertex is null)
                throw new ArgumentNullException($"Вершина с именем {name} отсутствует");

            return vertex;
        }

        /// <summary>
        /// Получить имена всех вершин в графе
        /// </summary>
        /// <returns>Лист имен</returns>
        public List<T> VerticesToNames()
        {
            var names = new List<T>();

            _vertices.ForEach(v => names.Add(v.Name));

            return names;
        }

        public override string ToString()
        {
            var message = "";

            foreach (var vertex in _vertices)
                message += $"Vertex: {vertex} \n";

            return message;
        }
    }
}
