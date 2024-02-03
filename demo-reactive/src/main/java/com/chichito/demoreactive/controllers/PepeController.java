package com.chichito.demoreactive.controllers;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.chichito.demoreactive.models.Pepe;
import com.chichito.demoreactive.services.PepeService;

import reactor.core.publisher.Mono;

@RestController
@RequestMapping("/personas")
public class PepeController {

    private final PepeService pepeService;

    public PepeController(PepeService pepeService) {
        this.pepeService = pepeService;
    }

    @PostMapping
    public Mono<Pepe> crear(@RequestBody Pepe pepe) {
        return pepeService.crear(pepe);
    }
}